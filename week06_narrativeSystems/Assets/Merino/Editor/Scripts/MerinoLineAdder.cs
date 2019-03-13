﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Merino;

// I pretty much just took this from YarnSpinnerConsole/LineAdder.cs
// https://github.com/thesecretlab/YarnSpinner/blob/master/YarnSpinnerConsole/LineAdder.cs

/*
public static class MerinoLineAdder {

	public struct LineInfo
	{
		public int lineNumber;
		public string nodeName;

		public LineInfo(string nodeName, int lineNumber)
		{
			this.nodeName = nodeName;
			this.lineNumber = lineNumber;
		}
	}

	static internal int AddLines(List<string> files)
    {
            var existingKeys = new List<string>();

            foreach (var file in files)
            {

                // NodeFormat fileFormat;
                // try
                // {
                //     fileFormat = Loader.GetFormatFromFileName(file);
                // }
                // catch (FormatException)
                // {
                //     fileFormat = NodeFormat.Unknown;
                // }

                // switch (fileFormat)
                // {
                //     case NodeFormat.JSON:
                //         break;
                //     case NodeFormat.Text:
                //         break;
                //     default:
                //         YarnSpinnerConsole.Warn(string.Format("Skipping file {0}, which is in unsupported format '{1}'", file, fileFormat));
                //         continue;
                // }

				var varStorage = new MerinoVariableStorage();
                Dialogue d = new Yarn.Dialogue ( varStorage );
                try
                {
                    // First, we need to ensure that this file compiles.
                    d.LoadFile(file);
                }
                catch
                {
                    Debug.LogWarningFormat("Skipping file {0} due to compilation errors.", file);
                    continue;
                }

                Dictionary<string, LineInfo> linesWithNoTag = new Dictionary<string, LineInfo>();

                // Filter the string info table to exclude lines that have a line code
                foreach (var entry in d.GetStringTable() )
                {
                    if (entry.Key.StartsWith("line:") == false)
                    {
                        linesWithNoTag[entry.Key] = entry.Value;
						// TODO: how to get line numbers?
                    }
                }

                if (linesWithNoTag.Count == 0)
                {
                    Debug.LogFormat("{0} had no untagged lines. Either they're all tagged already, or it has no localisable text.", file);
                    continue;
                }

                // We also need the raw NodeInfo structures contained within this file.
                // These contain the source code to what we just compiled.

                YarnSpinnerLoader.NodeInfo[] nodeInfoList;

                var nodeFormat = YarnSpinnerLoader.GetFormatFromFileName(file);

                using (var reader = new System.IO.StreamReader(file))
                {
                    nodeInfoList = YarnSpinnerLoader.GetNodesFromText(reader.ReadToEnd(), nodeFormat);
                }

                // Convert this list into an easier-to-index dictionary
                var lineInfo = new Dictionary<string, YarnSpinnerLoader.NodeInfo>();

                foreach (var node in nodeInfoList)
                {
                    lineInfo[node.title] = node;

                }

                // Make a list of line codes that we already know about.
                // This list will be updated as we tag lines, to prevent collisions.
                existingKeys.AddRange(lineInfo.Keys);

                bool anyNodesModified = false;

                // We now have a list of all strings that do not have a string tag.
                // Add a new tag to these lines.
                foreach (var line in linesWithNoTag)
                {

                    // TODO: There's quite a bit of redundant work done here in each loop.
                    // We're unzipping and re-combining the node for EACH line. Would be better
                    // to do that only once.

                    // Get the node that this line is in.
                    var nodeInfo = lineInfo[line.Value.nodeName];

                    // Is this line contained within a rawText node?
                    if (nodeInfo.tagsList.FindIndex(i => i == "rawText") != -1)
                    {
                        // We don't need to add a tag to it - genstrings will export
                        // the whole thing for us.
                        continue;
                    }

                    // If we have a tag to consider, and this node doesn't have that tag,
                    // continue
                    if (options.onlyUseTag != null)
                    {
                        if (nodeInfo.tagsList.FindIndex(i => i == options.onlyUseTag) == -1)
                        {
                            continue;
                        }
                    }


                    // Split this node's source by newlines
                    var lines = nodeInfo.body.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    // Get the original line
                    var existingLine = lines[line.Value.lineNumber - 1];

                    // Generate a new tag for this line
                    var newTag = GenerateString(existingKeys);

                    // Remember that we've used this tag, to prevent it from being re-used
                    existingKeys.Add(newTag);

                    if (options.verbose)
                    {
                        YarnSpinnerConsole.Note(string.Format("Tagged line with ID \"{0}\" in node {1}: {2}", newTag, nodeInfo.title, existingLine));
                    }

                    // Re-write the line.
                    var newLine = string.Format("{0} #{1}", existingLine, newTag);
                    lines[line.Value.lineNumber - 1] = newLine;


                    // Pack this all back up into a single string
                    nodeInfo.body = string.Join("\n", lines);

                    // Put the updated node in the node collection.
                    lineInfo[line.Value.nodeName] = nodeInfo;

                    anyNodesModified = true;

                }

                // If we didn't end up changing anything, don't modify the file
                if (anyNodesModified == false)
                {
                    continue;
                }

                // All the nodes have been updated; save this back to disk.

                // Are we doing a dry run?
                if (options.dryRun)
                {
                    // Then bail out at this point, before we start
                    // modifying files
                    YarnSpinnerConsole.Note("Would have written to file " + file);
                    continue;
                }

                var format = Loader.GetFormatFromFileName(file);

                switch (format)
                {
                    case NodeFormat.JSON:
                        break;
                    case NodeFormat.Text:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                // Convert the nodes into the correct format
                var savedData = FileFormatConverter.ConvertNodes(lineInfo.Values, fileFormat);


                // Write the file!
                using (var writer = new System.IO.StreamWriter(file))
                {
                    writer.Write(savedData);
                }


            }
            return 0;
        }


        static Random random = new Random();

        // Generates a new unique line tag that is not present in 'existingKeys'.
        static string GenerateString(List<string> existingKeys) {

            string tag = null;
            bool isUnique = true;
            do
            {
                tag = String.Format("line:{0:x6}", random.Next(0x1000000));

                isUnique = existingKeys.FindIndex(i => i == tag) == -1;

            } while (isUnique == false);

            return tag;
        }
}

*/
