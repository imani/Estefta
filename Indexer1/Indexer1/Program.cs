using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Lucene.Net;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using System.Xml;
using Lucene.Net.Documents;


namespace Indexer1
{
    class Program
    {
        static void Main(string[] args)
        {
        
           Lucene.Net.Store.Directory index_dir = FSDirectory.Open(@"..\..\..\LuceneIndex(subcat_not_anal)");
           Analyzer analyzer = new MyAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT);
           IndexWriter writer = new IndexWriter(index_dir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
           
            //reading files
            String path = @"D:\ComputerEngineer\Meshhkat\Ahkam2\second_edit\";
            DirectoryInfo dir = new DirectoryInfo(path);
            int counter = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                StreamReader reader = new StreamReader(file.FullName);
                if (file.Extension != ".xml")
                    continue;
                Document doc = new Document();
                XmlReader xreader = XmlReader.Create(reader);
                while(xreader.Read())
                {
                    String type = "answer";                    
                    if (xreader.NodeType == XmlNodeType.Element && (xreader.Name == "question" || xreader.Name == "answer"))
                    {
                        doc = new Document();
                        Field cat = new Field("cat", xreader.GetAttribute("cat"),Field.Store.YES, Field.Index.ANALYZED);
                        cat.Boost = 2.0f;
                        String s = xreader.GetAttribute("subcat");
                        Field subcat = new Field("subcat", xreader.GetAttribute("subcat"), Field.Store.YES, Field.Index.NOT_ANALYZED);
                        subcat.Boost = 3.0f;
                        if (xreader.Name == "question")
                            type = "question";

                        Field typeField = new Field("type", type, Field.Store.YES, Field.Index.NO);
                        Field id = new Field("id", xreader.GetAttribute("id"), Field.Store.YES, Field.Index.NO);
                        Field filename = new Field("file", file.Name,Field.Store.YES,Field.Index.NO);
                        doc.Add(filename);
                        doc.Add(typeField);
                        doc.Add(id);
                        doc.Add(cat);
                        doc.Add(subcat);
                        
                        
                    }
                    else if (xreader.NodeType == XmlNodeType.Text)
                    {
                        Field text = new Field("text", xreader.Value, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
                        doc.Add(text);
                    }
                    else if (xreader.NodeType == XmlNodeType.EndElement && (xreader.Name == "question" || xreader.Name == "answer"))
                    {
                        writer.AddDocument(doc);
                        if (counter++%55 == 0)
                            Console.Write(".");
           
                    }

                 }

            }
            writer.Optimize();
            writer.Commit();
            writer.Dispose();

           


           

        }
    }
}
