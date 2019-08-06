using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// classes dont need to be static when you are using InitializeOnLoad
[InitializeOnLoad]
public class LayerCodeGenerator
{
    private static LayerCodeGenerator instance;
    private CodeGeneratorCommon common = new CodeGeneratorCommon();

    private static CodeGeneratorCommon Com
    {
        get { return instance.common; }
    }

    private const string FileName = "Layers";

    private static string FilePath
    {
        get { return string.Format(CodeGeneratorCommon.FilePathFormat, CodeGeneratorCommon.DirPath, FileName); }
    }

    // static constructor
    static LayerCodeGenerator()
    {
        if (instance != null) return;
        instance = new LayerCodeGenerator {common = new CodeGeneratorCommon()};

        // Subscribe to editor update event
        EditorApplication.update += UpdateLayers;
        // get tags
        Com.names = GetNewName();
        // write file
        if (!File.Exists(FilePath))
        {
            WriteCodeFile();
        }
    }

    private static List<string> GetNewName()
    {
        return Enumerable.Range(0, 32).Select(x => LayerMask.LayerToName(x)).Where(y => y.Length > 0).ToList();
    }

    // update method that has to be called every frame in the editor
    private static void UpdateLayers()
    {
        if (Application.isPlaying) return;

        if (EditorApplication.timeSinceStartup < Com.nextCheckTime) return;
        Com.nextCheckTime = EditorApplication.timeSinceStartup + CodeGeneratorCommon.CheckIntervalSec;

        var newNames = GetNewName();
        if (Com.SomethingHasChanged(Com.names, newNames))
        {
            Com.names = newNames;
            WriteCodeFile();
        }
    }

    // writes a file to the project folder
    private static void WriteCodeFile()
    {
        Com.WriteCodeFile(FilePath, builder =>
        {
            WrappedInt indentCount = 0;
            builder.AppendIndentLine(indentCount, Com.AutoGenTemplate);
            builder.AppendIndentLine(indentCount, Com.NameSpaceTemplate);
            using (new CurlyIndent(builder, indentCount))
            {
                builder.AppendIndentFormatLine(indentCount, "public static class {0}", FileName);
                using (new CurlyIndent(builder, indentCount))
                {
                    foreach (string name in Com.names)
                    {
                        builder.AppendIndentFormatLine(indentCount, "private static string {0} = @\"{1}\";",
                            Com.MakeIdentifier(name), Com.EscapeDoubleQuote(name));
                        builder.AppendIndentFormatLine(indentCount,
                            "public static int {0} => UnityEngine.LayerMask.NameToLayer(" +
                            Com.MakeIdentifier(name) + ");\n", Com.MakeIdentifier("_" + name),
                            Com.EscapeDoubleQuote(name));
                    }
                }
            }
        });
    }
}