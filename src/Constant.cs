using System.Reflection;

namespace iPanelHost;

public static class Constant
{
    /// <summary>
    /// 版本
    /// </summary>
    public static readonly string VERSION = Assembly
        .GetExecutingAssembly()
        .GetName()
        .Version!.ToString();

    /// <summary>
    /// 内部版本
    /// </summary>
    public static readonly int InternalVersion = 1;

    public static readonly string Logo =
        @"
  _ ____                  _   _   _           _   
 (_)  _ \ __ _ _ __   ___| | | | | | ___  ___| |_ 
 | | |_) / _` | '_ \ / _ \ | | |_| |/ _ \/ __| __|
 | |  __/ (_| | | | |  __/ | |  _  | (_) \__ \ |_ 
 |_|_|   \__,_|_| |_|\___|_| |_| |_|\___/|___/\__|
 ";

    public static readonly string LogoIco =
        @"
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;121;190;233m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;207;237;255m  \x1b[48;2;207;237;255m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;171;223;255m  \x1b[48;2;171;223;255m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;207;237;255m  \x1b[48;2;207;237;255m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;121;190;233m  \x1b[48;2;171;223;255m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;207;237;255m  \x1b[48;2;207;237;255m  \x1b[48;2;207;237;255m  \x1b[48;2;171;223;255m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;207;237;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;85;163;211m  \x1b[48;2;85;163;211m  \x1b[48;2;171;223;255m  \x1b[48;2;59;111;144m  \x1b[48;2;59;111;144m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;87;113;128m  \x1b[48;2;87;113;128m  \x1b[48;2;171;223;255m  \x1b[48;2;56;81;96m  \x1b[48;2;56;81;96m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
        \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[48;2;111;138;154m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m  \x1b[0m
  _ ____                  _   _   _           _   
 (_)  _ \ __ _ _ __   ___| | | | | | ___  ___| |_ 
 | | |_) / _` | '_ \ / _ \ | | |_| |/ _ \/ __| __|
 | |  __/ (_| | | | |  __/ | |  _  | (_) \__ \ |_ 
 |_|_|   \__,_|_| |_|\___|_| |_| |_|\___/|___/\__|
";
}
