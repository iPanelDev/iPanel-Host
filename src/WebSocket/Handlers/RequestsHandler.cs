using iPanelHost.Base;
using iPanelHost.Base.Packets;
using iPanelHost.Base.Packets.Event;
using iPanelHost.Permissons;
using iPanelHost.Utils;
using iPanelHost.WebSocket.Client;
using iPanelHost.WebSocket.Client.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace iPanelHost.WebSocket.Handlers
{
    public static class RequestsHandler
    {
        /// <summary>
        /// 处理来自控制台的请求数据
        /// </summary>
        /// <param name="console">控制台客户端</param>
        /// <param name="packet">数据包</param>
        public static void Handle(Console console, ReceivedPacket packet)
        {
            Logger.Info($"<{console.Address}> 收到请求：{packet.SubType}，数据：{packet.Data?.ToString(Formatting.None) ?? "空"}");
            bool subAll;
            Instance? instance;

            switch (packet.SubType)
            {
                case "server_start":
                case "server_stop":
                case "server_kill":
                    if (!CheckTarget(console, out subAll, out instance) && instance is null)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InvalidTarget));
                        break;
                    }
                    Send(console, packet.SubType, null, subAll, instance);
                    console.Send(new OperationResultPacket(packet.Echo, ResultTypes.None));
                    break;

                case "server_input":
                    if (!CheckTarget(console, out subAll, out instance) && instance is null)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InvalidTarget));
                        break;
                    }
                    if (packet.Data is null || packet.Data.Type != JTokenType.Array)
                    {
                        console.Send(new InvalidDataPacket("“data”字段类型错误") { Echo = packet.Echo });
                        break;
                    }
                    Send(console, packet.SubType, packet.Data, subAll, instance);
                    console.Send(new OperationResultPacket(packet.Echo, ResultTypes.None));
                    break;

                case "list_instance":
                    console.Send(
                        new SentPacket(
                            "return",
                            "instance_list",
                            packet.Echo,
                            JArray.FromObject(MainHandler.Instances.Values)
                            ).ToString()
                        );
                    break;

                case "list_console":
                    console.Send(
                        new SentPacket(
                            "return",
                            "console_list",
                            packet.Echo,
                            JArray.FromObject(MainHandler.Consoles.Values)
                            ).ToString()
                        );
                    break;

                case "subscribe":
                    string? target = packet.Data?.ToString();
                    if (target == "*")
                    {
                        console.SubscribingTarget = target;
                    }
                    else if (
                        !string.IsNullOrEmpty(target) &&
                        (instance = MainHandler.Instances.Values.FirstOrDefault((i) => i.InstanceID == target)) is not null &&
                        (console.User?.Level == PermissonLevel.Assistant || console.User?.Level == PermissonLevel.Administrator || (console.User?.Instances.Contains(target) ?? false)))
                    {
                        console.SubscribingTarget = target;
                        console.Send(new SentPacket(
                            "return",
                            "instance_info",
                            packet.Echo,
                            new JObject
                            {
                                { "instance_id", target },
                                { "info", JObject.FromObject(instance.FullInfo) }
                            }));
                    }
                    else
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InvalidTarget));
                    }
                    break;

                case "dissubscribe":
                    console.SubscribingTarget = null;
                    break;

                case "get_instance_info":
                    if (!string.IsNullOrEmpty(packet.Data?.ToString()) && MainHandler.Instances.TryGetValue(packet.Data?.ToString()!, out instance))
                    {
                        console.Send(new SentPacket(
                            "return",
                            "instance_info",
                            packet.Echo,
                            new JObject
                            {
                                { "instance_id", console.SubscribingTarget },
                                { "info", JObject.FromObject(instance.FullInfo) }
                            }));
                    }
                    else if (packet.Data?.ToString() == "*")
                    {
                        Dictionary<string, FullInfo> fullInfos = new();
                        MainHandler.Instances.Values.ToList().ForEach((i) => fullInfos.Add(i.InstanceID!, i.FullInfo));
                        console.Send(new SentPacket(
                            "return",
                            "instances_info",
                            packet.Echo,
                            fullInfos
                            ));
                    }
                    else
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InvalidTarget));
                    }
                    break;

                case "get_current_user_info":
                    if (console.User is null)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InternalDataError));
                        throw new InternalException("用户为空");
                    }
                    console.Send(new SentPacket(
                        "return",
                        "user_info",
                        packet.Echo,
                        new User.PublicUser(console.User)
                        ));
                    break;

                case "get_all_users":
                    if (console.User?.Level != PermissonLevel.Administrator)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.PermissionDenied));
                        break;
                    }
                    console.Send(
                        new SentPacket(
                            "return",
                            "user_dict",
                            packet.Echo,
                            UserManager.Users
                                .Select((kv) => new KeyValuePair<string, User.PublicUser>(kv.Key, kv.Value))
                                .ToDictionary((kv) => kv.Key, (kv) => kv.Value)
                            ));
                    break;

                case "delete_user":
                    if (console.User?.Level != PermissonLevel.Administrator)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.PermissionDenied));
                        break;
                    }
                    if (packet.Data is null)
                    {
                        console.Send(new InvalidDataPacket("“data”字段为null") { Echo = packet.Echo });
                        break;
                    }

                    console.Send(new OperationResultPacket(
                        packet.Echo,
                        UserManager.Users.Remove(packet.Data.ToString()) ?
                        ResultTypes.None :
                        ResultTypes.InvalidUser));
                    UserManager.Save();
                    console.Send(
                        new SentPacket(
                            "return",
                            "user_dict",
                            packet.Echo,
                            UserManager.Users
                                .Select((kv) => new KeyValuePair<string, User.PublicUser>(kv.Key, kv.Value))
                                .ToDictionary((kv) => kv.Key, (kv) => kv.Value)
                            ));
                    break;

                case "get_dir_info":
                    if (console.User?.Level != PermissonLevel.Assistant && console.User?.Level != PermissonLevel.Administrator)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.PermissionDenied));
                        break;
                    }
                    if (!CheckTarget(console, out subAll, out instance) && instance is null)
                    {
                        console.Send(new OperationResultPacket(packet.Echo, ResultTypes.InvalidTarget));
                        break;
                    }
                    if (packet.Data is null)
                    {
                        console.Send(new InvalidDataPacket("“data”字段为null") { Echo = packet.Echo });
                        break;
                    }
                    Send(console, packet.SubType, packet.Data, subAll, instance);
                    break;


                default:
                    console.Send(new InvalidParamPacket($"所请求的“{packet.SubType}”类型不存在或无法调用") { Echo = packet.Echo });
                    break;
            }
        }

        /// <summary>
        /// 检查目标
        /// </summary>
        /// <param name="console">控制台客户端</param>
        /// <param name="packet">数据包</param>
        /// <returns>检查结果</returns>
        private static bool CheckTarget(Console console, out bool subAll, out Instance? instance)
        {
            instance = null;
            subAll = console.SubscribingTarget == "*";
            if (subAll)
            {
                return true;
            }
            return
                !string.IsNullOrEmpty(console.SubscribingTarget) &&
                (instance = MainHandler.Instances.FirstOrDefault((kv) => kv.Value.InstanceID == console.SubscribingTarget).Value) is not null;
        }

        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="console">控制台客户端</param>
        /// <param name="subType">子类型</param>
        /// <param name="data">数据主体</param>
        /// <param name="subAll">订阅目标为全体</param>
        /// <param name="instance">实例对象</param>
        private static void Send(Console console, string subType, object? data, bool subAll = false, Instance? instance = null)
        {
            if (subAll)
            {
                lock (MainHandler.Instances)
                {
                    MainHandler.Instances.Values.ToList().ForEach((enumeredInstance) => enumeredInstance?.Send(new SentPacket("request", subType, data, Sender.From(console)).ToString()));
                }
            }
            else
            {
                instance?.Send(new SentPacket("request", subType, data, Sender.From(console)).ToString());
            }
        }
    }
}