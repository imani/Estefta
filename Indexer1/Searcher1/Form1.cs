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
        public QueryParser text_parser;
        public QueryParser cat_parser;
        public QueryParser subcat_parser;
        public Indexer1.MyAnalyzer my_analyzer;
        public XPathDocument categories;
        public XPathNavigator nav;
        public Form1()
        {
            InitializeComponent();
            Lucene.Net.Store.Directory dir = FSDirectory.Open(@"..\..\..\LuceneIndex(q_boost15)");
            searcher = new IndexSearcher(dir, true);
            my_analyzer = new Indexer1.MyAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT);
            text_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "text", my_analyzer);
            cat_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "cat", my_analyzer);
            subcat_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "subcat", my_analyzer);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String path = @"D:\ComputerEngineer\Meshhkat\Ahkam2\categories.xml";
            categories = new XPathDocument(path);
            nav = categories.CreateNavigator();
            var expr = nav.Compile("//cat");
            XPathNodeIterator iter = nav.Select(expr);
            while (iter.MoveNext())
            {
                cmb_cat.Items.Add(iter.Current.Value);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            int Score_adjuster = 0;
            txt_answer.ResetText();
            var query = text_parser.Parse(txt_query.Text);
            var queryString = String.Format("({0}) OR ({1}) OR ({2})", query, query.ToString().Replace("text", "cat"), query.ToString().Replace("text", "subcat"));
            if (cmb_cat.SelectedItem != null)
            {
                Score_adjuster = -2;
                var cat_query = cat_parser.Parse(cmb_cat.SelectedItem.ToString());
                if (cmb_subcat.SelectedItem != null)
                {
                    Score_adjuster = -3;
                    Query subcat_query = subcat_parser.Parse(cmb_subcat.SelectedItem.ToString());
                    queryString = String.Format("({0}) AND ({1}) AND ({2})", query, cat_query, subcat_query);
                }
                else
                    queryString = String.Format("({0}) AND ({1})", query, cat_query);
            }
            try
            {
                query = text_parser.Parse(queryString);
            }
            catch (Exception exp)
            {
                return;
            }

            var result = searcher.Search(query,10);
            var first = true;
            foreach (ScoreDoc sd in result.ScoreDocs)
            {
                sd.Score += Score_adjuster;
                if ((!first && sd.Score < 0.5) || sd.Score<0.1)
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
                if (first == true)
                    first = false;
            }

            
            
        }

        private void cmb_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_subcat.Items.Clear();
            cmb_subcat.ResetText();
            var expr = nav.Compile("//subcat[@cat='"+cmb_cat.SelectedItem+"']");
            XPathNodeIterator iter = nav.Select(expr);
            while(iter.MoveNext())
            {
                cmb_subcat.Items.Add(iter.Current.Value);
            }
            
        }

        
    }
}
