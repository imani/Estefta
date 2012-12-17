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


namespace Searcher1
{
    public partial class Form1 : Form
    {
        private String path = @"D:\ComputerEngineer\Meshhkat\Ahkam2\second_edit\";
        public IndexSearcher searcher;
        public QueryParser parser;
        public Indexer1.MyAnalyzer my_analyzer;
        public Form1()
        {
            InitializeComponent();
            Lucene.Net.Store.Directory dir = FSDirectory.Open(@"..\..\..\LuceneIndex");
            searcher = new IndexSearcher(dir, true);
            my_analyzer = new Indexer1.MyAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT);
            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "text", my_analyzer);
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            txt_answer.ResetText();
            var query = parser.Parse(txt_query.Text);
            var queryString = String.Format("({0}) OR ({1}) OR ({2})", query, query.ToString().Replace("text", "cat"), query.ToString().Replace("text", "subcat"));
            query = parser.Parse(queryString);
            var result = searcher.Search(query,10);
            foreach (ScoreDoc sd in result.ScoreDocs)
            {
                if (sd.Score < 0.1)
                    continue;
                var resdoc = searcher.Doc(sd.Doc);
                XPathDocument xdoc = new XPathDocument(path + resdoc.Get("file"));
                XPathNavigator nav = xdoc.CreateNavigator();
                XPathExpression expr = nav.Compile("//*[@id=" + resdoc.Get("id") + "]");
                XPathNodeIterator iter = nav.Select(expr);
                txt_answer.AppendText("Score= " + sd.Score);
                while (iter.MoveNext())
                    txt_answer.AppendText(iter.Current.Value + "\n\n");
                txt_answer.AppendText("\n\t\t-------------------------------------------------\n");
            }

            
            
        }

        
    }
}
