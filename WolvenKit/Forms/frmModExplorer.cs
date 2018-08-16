﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Editors;
using WolvenKit.Mod;

namespace WolvenKit
{
    public partial class frmModExplorer : DockContent
    {
        public frmModExplorer()
        {
            InitializeComponent();
            UpdateModFileList(true,true);
        }

        public W3Mod ActiveMod
        {
            get { return MainController.Get().ActiveMod; }
            set { MainController.Get().ActiveMod = value; }
        }

        public event EventHandler<RequestFileArgs> RequestFileOpen;
        public event EventHandler<RequestFileArgs> RequestFileDelete;
        public event EventHandler<RequestFileArgs> RequestFileAdd;
        public event EventHandler<RequestFileArgs> RequestFileRename;
        public List<string> FilteredFiles; 
        public bool FoldersShown = true;


        public bool DeleteNode(string fullpath)
        {
            var parts = fullpath.Split('\\');
            var current = modFileList.Nodes;
            for (var i = 0; i < parts.Length; i++)
            {
                if (current.ContainsKey(parts[i]))
                {
                    var node = current[parts[i]];
                    current = node.Nodes;

                    if (i == parts.Length - 1)
                    {
                        node.Remove();
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        public void UpdateModFileList(bool showfolders,bool clear = false)
        {
            if (ActiveMod == null)
                return;

            if (FilteredFiles == null || FilteredFiles.Count == 0)
            {
                FilteredFiles = ActiveMod.Files;
            }
            if (clear)
            {
                modFileList.Nodes.Clear();
            }

            foreach (var item in FilteredFiles)
            {
                var current = modFileList.Nodes;
                if (!showfolders)
                {
                    var newNode = current.Add(item, item);
                    if (treeImages.Images.ContainsKey(Path.GetExtension(item).Replace(".", "")))
                    {
                        newNode.ImageKey = Path.GetExtension(item).Replace(".", "");
                        newNode.ImageKey = Path.GetExtension(item).Replace(".", "");
                    }
                    else
                    {
                        newNode.ImageKey = "genericFile";
                        newNode.ImageKey = "genericFile";
                    }
                }
                else
                {
                    var parts = item.Split('\\');
                    for (var i = 0; i < parts.Length; i++)
                    {
                        if (!current.ContainsKey(parts[i]))
                        {

                            var newNode = current.Add(parts[i], parts[i]);
                            if (i == parts.Length - 1)
                            {
                                if (treeImages.Images.ContainsKey(Path.GetExtension(item).Replace(".", "")))
                                {
                                    newNode.ImageKey = Path.GetExtension(item).Replace(".", "");
                                    newNode.ImageKey = Path.GetExtension(item).Replace(".", "");
                                }
                                else
                                {
                                    newNode.ImageKey = "genericFile";
                                    newNode.ImageKey = "genericFile";
                                }
                            }
                            else
                            {
                                newNode.ImageKey = "openFolder";
                                newNode.SelectedImageKey = "openFolder";
                            }
                            newNode.Parent?.Expand();
                            current = newNode.Nodes;
                        }
                        else
                        {
                            current = current[parts[i]].Nodes;
                        }
                    }

                }
            }
        }

        private void modFileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RequestFileOpen?.Invoke(this, new RequestFileArgs {File = e.Node.FullPath});
        }

        private void removeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modFileList.SelectedNode != null)
            {
                RequestFileDelete?.Invoke(this, new RequestFileArgs {File = modFileList.SelectedNode.FullPath});
            }
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestFileAdd?.Invoke(this,new RequestFileArgs {File = GetExplorerString(modFileList.SelectedNode?.FullPath ?? "")});
        }

        private void modFileList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                modFileList.SelectedNode = e.Node;
                contextMenu.Show(modFileList, e.Location);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modFileList.SelectedNode != null)
            {
                RequestFileRename?.Invoke(this, new RequestFileArgs {File = modFileList.SelectedNode.FullPath});
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modFileList.SelectedNode != null)
            {
                Clipboard.SetText(MainController.Get().ActiveMod.FileDirectory + "\\" + modFileList.SelectedNode.FullPath);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Clipboard.GetText()))
            {
                FileAttributes attr = File.GetAttributes(ActiveMod.FileDirectory + "\\" + modFileList.SelectedNode.FullPath);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    SafeCopy(Clipboard.GetText(), ActiveMod.FileDirectory + "\\" + modFileList.SelectedNode.FullPath + "\\" + Path.GetFileName(Clipboard.GetText()));
                }
                else
                {
                    SafeCopy(Clipboard.GetText(), Path.GetDirectoryName(ActiveMod.FileDirectory + "\\" + modFileList.SelectedNode.FullPath) + "\\" + Path.GetFileName(Clipboard.GetText()));
                }
            }
        }

        private void contextMenu_Opened(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Enabled = File.Exists(Clipboard.GetText());
        }

        public static IEnumerable<string> FallbackPaths(string path)
        {
            yield return path;

            var dir = Path.GetDirectoryName(path);
            var file = Path.GetFileNameWithoutExtension(path);
            var ext = Path.GetExtension(path);

            yield return Path.Combine(dir, file + " - Copy" + ext);
            for (var i = 2; ; i++)
            {
                yield return Path.Combine(dir, file + " - Copy " + i + ext);
            }
        }
        public static void SafeCopy(string src, string dest)
        {
            foreach (var path in FallbackPaths(dest).Where(path => !File.Exists(path)))
            {
                File.Copy(src, path);
                break;
            }
        }

        private void showhideButton_Click(object sender, EventArgs e)
        {
            FoldersShown = !FoldersShown;
            UpdateModFileList(FoldersShown,true);
        }

        private void UpdatefilelistButtonClick(object sender, EventArgs e)
        {
            FoldersShown = true;
            FilteredFiles = ActiveMod.Files;
            UpdateModFileList(true,true);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                FilteredFiles = ActiveMod.Files;
                UpdateModFileList(true, true);
                return;
            }
            FilteredFiles = ActiveMod.Files.Where(x => (x.Contains('\\') ? x.Split('\\').Last() : x).ToUpper().Contains(searchBox.Text.ToUpper())).ToList();
            UpdateModFileList(FoldersShown, true);
        }

        private void FileChanges_Detected(object sender, FileSystemEventArgs e)
        {
            FilteredFiles = ActiveMod.Files;
            UpdateModFileList(FoldersShown, true);
        }


        private void frmModExplorer_Shown(object sender, EventArgs e)
        {
            if(ActiveMod != null)
                modexplorerSlave.Path = ActiveMod.FileDirectory;
        }

        private void modFileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && modFileList.SelectedNode != null)
            {
                RequestFileRename?.Invoke(this, new RequestFileArgs { File = modFileList.SelectedNode.FullPath });
            }
        }

        private void showFileInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modFileList.SelectedNode != null)
            {
                Commonfunctions.ShowFileInExplorer(ActiveMod.FileDirectory + "\\" + modFileList.SelectedNode.FullPath);
            }
        }

        private void ExpandBTN_Click(object sender, EventArgs e)
        {
            modFileList.ExpandAll();
        }

        private void CollapseBTN_Click(object sender, EventArgs e)
        {
            modFileList.CollapseAll();
        }

        public void StopMonitoringDirectory()
        {
            modexplorerSlave.Dispose();
        }

        private void copyRelativePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(modFileList.SelectedNode != null)
                Clipboard.SetText(GetArchivePath(modFileList.SelectedNode.FullPath));
        }

        private void markAsModDlcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modFileList.SelectedNode != null)
            {
                var filename = modFileList.SelectedNode.FullPath;
                var fullpath = Path.Combine(ActiveMod.FileDirectory, filename);
                if (!File.Exists(fullpath))
                    return;
                var newfullpath = Path.Combine(new[] { ActiveMod.FileDirectory, filename.Split('\\')[0] == "DLC" ? "Mod" : "DLC" }.Concat(filename.Split('\\').Skip(1).ToArray()).ToArray());

                if (File.Exists(newfullpath))
                    return;
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newfullpath));
                }
                catch
                {
                }
                File.Move(fullpath, newfullpath);
                MainController.Get().ProjectStatus = "File moved";
            }
        }

        public string GetExplorerString(string s)
        {
            if (s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length > 1)
            {
                var r = string.Join(Path.DirectorySeparatorChar.ToString(), new[] { "Root" }.Concat(s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Skip(1)).ToArray());
                return string.Join(Path.DirectorySeparatorChar.ToString(), new[] {"Root" }.Concat(s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Skip(1)).ToArray());
            }
            else
                return s;
        }

        public string GetArchivePath(string s)
        {
            if (s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length > 2)
            {
                return string.Join(Path.DirectorySeparatorChar.ToString(), s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Skip(2).ToArray());
            }
            else
                return s;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Get all files in a list
            List<CR2WFile> W2SceneFiles = new List<CR2WFile>();
            List<string> AllFiles = new List<string>();

            AllFiles = ActiveMod.Files;
            

            for (int i = 0; i < AllFiles.Count; i++)
            {
                //open the file and perform operations
                var fullpath = Path.Combine(ActiveMod.FileDirectory, AllFiles[i]);
                CR2WFile file;

                using (var fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(fs))
                    {
                        file = new CR2WFile(reader)
                        {
                            FileName = fullpath,
                            EditorController = MainController.Get(),
                            LocalizedStringSource = MainController.Get()
                        };
                    }
                    fs.Close();
                }

                //remove scene lights variable (chunk0)
                try
                {
                    IEditableVariable StoryScene = file.chunks[0].GetEditableVariables().Find(x => x.Name.Contains("CStoryScene"));
                    StoryScene.RemoveVariable(StoryScene.GetEditableVariables().Find(x => x.Name.Contains("sceneLights")));
                }
                catch (Exception ex)
                {
                    //output ex
                }


                //CStorySceneCutsceneSection: sceneEventElements(array) : for each entry remove lightmod1, lightmod2 variable
                List<CR2WChunk> ChunksToEdit = new List<CR2WChunk>();

                ChunksToEdit.AddRange(file.chunks.FindAll(x => x.Type.Equals("CStorySceneCutsceneSection")));
                ChunksToEdit.AddRange(file.chunks.FindAll(x => x.Type.Equals("CStorySceneSection")));

                for (int j = 0; j < ChunksToEdit.Count; j++)
                {
                    List<IEditableVariable> SceneEventElements = new List<IEditableVariable>();
                    try
                    {
                        SceneEventElements.AddRange(ChunksToEdit[j].data.GetEditableVariables().Find(x => x.Name.Contains("sceneEventElements")).GetEditableVariables());
                    }
                    catch (Exception ex)
                    {
                        //output ex
                    }
                    try
                    {
                        SceneEventElements.AddRange(ChunksToEdit[j].data.GetEditableVariables().Find(x => x.Name.Contains("sceneEventElements")).GetEditableVariables());
                    }
                    catch (Exception ex)
                    {
                        //output ex
                    }
                    for (int k = 0; k < SceneEventElements.Count; k++)
                    {
                        SceneEventElements[k].RemoveVariable(SceneEventElements[k].GetEditableVariables().Find(x => x.Name.Contains("lightMod1")));
                        SceneEventElements[k].RemoveVariable(SceneEventElements[k].GetEditableVariables().Find(x => x.Name.Contains("lightMod2")));
                    }
                }


                //output one file
                MainController.Get().Window.AddOutput("Finished file: " + i + "/chunks: " + ChunksToEdit.Count + "\n");

                //doc.SaveFile();
                using (var mem = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(mem))
                    {
                        file.Write(writer);
                        mem.Seek(0, SeekOrigin.Begin);

                        using (var fs = new FileStream(file.FileName, FileMode.Create, FileAccess.Write)) //FILENAME
                        {
                            mem.WriteTo(fs);
                            fs.Close();
                        }
                    }
                }
            }
            

            //output done all
            MainController.Get().Window.AddOutput("Finished until: " + AllFiles.Count + "\n");


        }
    }
}