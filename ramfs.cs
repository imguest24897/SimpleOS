using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOS
{
    // A class representing a file in RAMFS
    public class RamFile
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }

        public RamFile(string name)
        {
            Name = name;
            Content = new byte[0];
        }
    }

    // A class representing a directory in RAMFS
    public class RamDirectory
    {
        public string Name { get; set; }
        public Dictionary<string, RamFile> Files { get; private set; }
        public Dictionary<string, RamDirectory> Directories { get; private set; }

        public RamDirectory(string name)
        {
            Name = name;
            Files = new Dictionary<string, RamFile>();
            Directories = new Dictionary<string, RamDirectory>();
        }

        public void CreateFile(string name)
        {
            if (!Files.ContainsKey(name))
            {
                Files[name] = new RamFile(name);
            }
            else
            {
                throw new Exception($"File '{name}' already exists.");
            }
        }

        public void CreateDirectory(string name)
        {
            if (!Directories.ContainsKey(name))
            {
                Directories[name] = new RamDirectory(name);
            }
            else
            {
                throw new Exception($"Directory '{name}' already exists.");
            }
        }

        public RamFile GetFile(string name)
        {
            if (Files.ContainsKey(name))
            {
                return Files[name];
            }
            else
            {
                throw new Exception($"File '{name}' not found.");
            }
        }

        public RamDirectory GetDirectory(string name)
        {
            if (Directories.ContainsKey(name))
            {
                return Directories[name];
            }
            else
            {
                throw new Exception($"Directory '{name}' not found.");
            }
        }
    }

    // The RAMFS class
    public class RamFs
    {
        public RamDirectory RootDirectory { get; private set; }

        public RamFs()
        {
            RootDirectory = new RamDirectory("root");
        }

        public void CreateFile(string path)
        {
            var parts = path.Split('/');
            var currentDir = RootDirectory;

            for (int i = 0; i < parts.Length - 1; i++)
            {
                currentDir = currentDir.GetDirectory(parts[i]);
            }

            currentDir.CreateFile(parts[^1]);
        }

        public void CreateDirectory(string path)
        {
            var parts = path.Split('/');
            var currentDir = RootDirectory;

            for (int i = 0; i < parts.Length; i++)
            {
                if (!currentDir.Directories.ContainsKey(parts[i]))
                {
                    currentDir.CreateDirectory(parts[i]);
                }

                currentDir = currentDir.GetDirectory(parts[i]);
            }
        }

        public RamFile GetFile(string path)
        {
            var parts = path.Split('/');
            var currentDir = RootDirectory;

            for (int i = 0; i < parts.Length - 1; i++)
            {
                currentDir = currentDir.GetDirectory(parts[i]);
            }

            return currentDir.GetFile(parts[^1]);
        }

        public RamDirectory GetDirectory(string path)
        {
            var parts = path.Split('/');
            var currentDir = RootDirectory;

            for (int i = 0; i < parts.Length; i++)
            {
                currentDir = currentDir.GetDirectory(parts[i]);
            }

            return currentDir;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ramFs = new RamFs();

            ramFs.CreateDirectory("sys");
            ramFs.CreateFile("sys/README.txt");

            RamFile file = ramFs.GetFile("sys/README.txt");
            file.Content = Encoding.ASCII.GetBytes("THIS IS SYSTEM FOLDER. DON'T DELETE IT TO AVOID ANY HARM TO SIMPLEOS!\nALSO REMOVING EVERYTHING IN / FOLDER CAN CAUSE MEMORY TO ERASE FULLY, BY MAKING YOUR COMPUTER UNUSABLE!");

            Console.WriteLine("File content: " + Encoding.ASCII.GetString(file.Content));
        }
    }
}
