using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.QueryParsers;
using System.Xml.XPath;
using System.IO;


namespace Searcher1
{
    public partial class Form1 : Form
    {
        private String path = @"..\..\..\data\";
        public IndexSearcher searcher;
        public QueryParser text_parser;
        public Indexer1.MyAnalyzer my_analyzer;
        public XPathDocument categories;
        public XPathNavigator nav;
        // check tree utilities
        private List<String> checked_cats = new List<string>();
        private List<String> checked_subcats = new List<string>();
        private Dictionary<String, List<String>> synonyms;

        private TopDocs result;
        public Form1()
        {
            InitializeComponent();
            Lucene.Net.Store.Directory dir = FSDirectory.Open(@"..\..\..\LuceneIndex(q_boost15_AND_PositionOffset)");
            searcher = new IndexSearcher(dir, true);
            my_analyzer = new Indexer1.MyAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT);
            text_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "text", my_analyzer);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String path = @"..\..\..\data\categories.xml";
            categories = new XPathDocument(path);
            nav = categories.CreateNavigator();
            var expr = nav.Compile("//*");
            XPathNodeIterator iter = nav.Select(expr);
            String category = null;
            List<TreeNode> subcats = new List<TreeNode>() ;
            while (iter.MoveNext())
            {
                if(iter.Current.Name == "cat")
                {
                    if(subcats.Count != 0)
                    {
                        TreeNode cat_node = new TreeNode(category, subcats.ToArray());
                        trv_categories.Nodes.Add(cat_node);
                        subcats.Clear();
                    }
                    category = iter.Current.Value;
                }
                else if(iter.Current.Name == "subcat")
                {
                    subcats.Add(new TreeNode(iter.Current.Value));
                }
            }

            path = @"..\..\..\data\";
            synonyms = new Dictionary<string, List<string>>();
            StreamReader reader = new StreamReader(path+"synonyms.txt", Encoding.UTF8);
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                if (line.Length <= 0)
                    continue;
                line = line.Trim();
                List<String> syms = line.Split(':','،',',').ToList<String>();
                for (int i = 0; i < syms.Count; i++)
                    syms[i] = syms[i].Trim();
                String key = syms[0];
                syms.RemoveAll(s => s.Length <= 0);
                syms.RemoveAt(0);
                if (synonyms.ContainsKey(key))
                    synonyms[key].Concat(syms);
                else
                    synonyms.Add(key, syms);
            }
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String q = txt_query.Text;
            foreach(String token in txt_query.Text.Split(' ','.','?'))
            {
                if( !synonyms.ContainsKey(token))
                    continue;
                foreach( String syn in synonyms[token])
                    q = q + " " + syn;
            }
            var query = text_parser.Parse(q);
            var cat_query = text_parser.Parse(txt_query.Text);
            var queryString = String.Format("({0}) OR ({1}) OR ({2})", query, cat_query.ToString().Replace("text", "cat"), cat_query.ToString().Replace("text", "subcat"));
            try
            {
                query = text_parser.Parse(queryString);
            }
            catch (Exception exp)
            {
                return;
            }

            result = searcher.Search(query,20);
            ShowResult(result);            
        }

        

        private void trv_categories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            String item = e.Node.Text;
            if (e.Node.Parent == null)
                if (e.Node.Checked)
                {
                    checked_cats.Add(item);
                }
                else
                    checked_cats.Remove(item);
            else
            {
                if (e.Node.Checked)
                    checked_subcats.Add(item);
                else
                    checked_subcats.Remove(item);
            }

            try
            {
                ShowResult(result);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void ShowResult(TopDocs result)
        {
            int Score_adjuster = 0;
            var first = true;
            txt_answer.ResetText();
            foreach (ScoreDoc sd in result.ScoreDocs)
            {
                sd.Score += Score_adjuster;
                //if ((!first && sd.Score < 0.5) || sd.Score < 0.1)
                //    continue;

                var resdoc = searcher.Doc(sd.Doc);
                String res_cat = resdoc.GetField("cat").StringValue;
                String res_subcat = resdoc.GetField("subcat").StringValue;
                if (checked_cats.Count == 0)
                {
                    if (checked_subcats.Count != 0 && checked_subcats.Contains(res_subcat) == false)
                        continue;
                }
                else
                {
                    if (checked_cats.Contains(res_cat) == false)
                    {
                        if (checked_subcats.Count == 0)
                            continue;
                        else if (checked_subcats.Contains(res_subcat) == false)
                            continue;
                    }
                }
                XPathDocument xdoc = new XPathDocument(path + resdoc.Get("file"));
                XPathNavigator nav = xdoc.CreateNavigator();
                XPathExpression expr = nav.Compile("//*[@id=" + resdoc.Get("id") + "]");
                XPathNodeIterator iter = nav.Select(expr);
                txt_answer.AppendText("Score= " + sd.Score);
                while (iter.MoveNext())
                    txt_answer.AppendText(iter.Current.Value + "\n\n");
                txt_answer.AppendText("\n\t\t-------------------------------------------------\n");
                if (first == true)
                    first = false;
            }
        }

        private void txt_query_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btn_search_Click(sender, e);
        }

        private void showBestMatch(TopDocs result)
        {
            float max = 0;
            foreach (ScoreDoc sd in result.ScoreDocs)
            {

            }
        }


    
    }
}
