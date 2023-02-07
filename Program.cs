using System;
using System.Net;
using System.Threading;
using System.Diagnostics;

string welcome = "Welcome to Minecraft Server Installer\n";

foreach (char c in welcome)
{
    Console.Write(c);
    Thread.Sleep(50);
}
Console.WriteLine();


string verze = "Select version:\n";
foreach (char b in verze)
{
    Console.Write(b);
    Thread.Sleep(50);
}
Console.WriteLine();



string vse = "1.12.2\n" +
             "1.13.2\n" +
             "1.14.4\n" +
             "1.15.2\n" +
             "1.16.5\n" +
             "1.17.1\n" +
             "1.18.2\n" +
             "1.19\n" +
             "1.19.3\n";
foreach (char a in vse)
{
    Console.Write(a);
    Thread.Sleep(50);
}
Console.WriteLine();


string choosen = Console.ReadLine();
if (args.Equals(choosen))
{
    using (var client = new WebClient())
    {
        client.DownloadFile("https://cdn.getbukkit.org/spigot/spigot-" + "", "Spigot-" + choosen +".jar");
    }
}
Console.WriteLine("Download complete!!\n");
Console.WriteLine("Agree to the EULA? Y/n\n");
string jo = Console.ReadLine();
if (jo == "Y")
{
    string text = "eula=true";
    File.WriteAllText("eula.txt", text);
} else
{
    Console.WriteLine("Do you disagree? Therefore, we have to terminate the program");
    return;
}
Console.WriteLine("Run the run.bat file to start the server!!\n");
string command = "@echo off\ntitle Minecraft Server\njava -jar Spigot-" + choosen + ".jar nogui\nPAUSE";
File.WriteAllText("run.bat", command);
Console.WriteLine("A run.bat file would be created");
Console.WriteLine("I'm running Minecraft Server!!\n");
Process process = new Process();
process.StartInfo.FileName = "java";
process.StartInfo.Arguments = "-jar Spigot-" + choosen + ".jar nogui";
process.Start();