using System.Xml;

var u = new FileManager();
u.Action();
public partial class FileManager
{
    public void Action()
    {
        var msg = $"{Environment.NewLine}You can do following things:{Environment.NewLine}" +
                  $"\tls - See available Data in this Directory{Environment.NewLine}" +
                  $"\tup - Go to Parent Folder{Environment.NewLine}" +
                  $"\topen -Open Folder{Environment.NewLine}" +
                  $"\topenTxt - ReadFile{Environment.NewLine}" +
                  $"\tcreate - CreateFolder{Environment.NewLine}" +
                  $"\tdelete - DeleteFolder{Environment.NewLine}" +
                  $"\ttree - ShowTree{Environment.NewLine}" +
                  $"\texit - Exit{Environment.NewLine}";
        
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_curDir.FullName + ">");
            Console.ForegroundColor = ConsoleColor.White;
            var op = Console.ReadLine();
            
            switch (op)
            {
                case "help":
                    Console.WriteLine(msg);
                    break;
                case "ls":
                    CurrentSurroundings();
                    break;
                case "up":
                    this.MoveUp();
                    break;
                case "open":
                    OpenFolder();
                    break;
                case "openTxt":
                    OpenTxt();
                    break;
                case "create":
                    CreateFolder();
                    break;
                case "delete":
                    DeleteFolder();
                    break;
                case "tree":
                {
                    var dir = new DirectoryInfo(@"C:\");
                    //Console.Write(dir.Name);
                    using var sw = new StreamWriter($"{_curDir.FullName}\\trace.txt");
                    DrawTree(dir, "", sw);
                    break;
                }
                case "exit":
                    return;
                default:
                    Console.WriteLine($"Command {op} does not exist");
                break;
            }
        }

    }
}