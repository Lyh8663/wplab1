using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;

using Utils;

using WPFTest.UI.Menu;
using WPFTest.UI.Index;
using WPFTest.UI.Chapter1;
using WPFTest.UI.Chapter2;
using WPFTest.UI.Chapter3;
using WPFTest.UI.Chapter6;
using WPFTest.UI.Chapter7;
using WPFTest.UI.Chapter8;
using WPFTest.UI.Chapter9;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public HeadPage headPage = new HeadPage();
        public MainMenuPage mainMenuPage = new MainMenuPage();

        public MainWindow()
        {

            InitializeComponent();

            //定义委托事件的lamda实现函数
            headPage.NextEvent += ((object arg) =>
            {
                MessageBox.Show("正在开发中......");
            });
            headPage.QuitEvent += ((object arg) =>
            {
                this.Close();
            });
            

            headPage.parentWindow = this;
            headFrame.Content = headPage;



            mainMenuPage.parentWindow = this;
            mainMenuFrame.Content = mainMenuPage;

            /*
            try
            {
                SqlserverUtil dbutil = new SqlserverUtil();
                SqlConnection connection = dbutil.connect();
                dbutil.close(connection);
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("数据库连接异常,请检查配置", "警告");
                this.Close();
            }
             */
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }



        public void createLeftMenuPage(string topMenuName)
        {
            Page page = null;

            if ("index".Equals(topMenuName))
                page = createPageIndex();
            else if ("fgbz".Equals(topMenuName))
                page = createPageFgbz();
            else if ("chapter1".Equals(topMenuName))
                page = createPageChapter1();
            else if ("chapter2".Equals(topMenuName))
                page = createPageChapter2();
            else if ("chapter3".Equals(topMenuName))
                page = createPageChapter3();
            else if ("chapter6".Equals(topMenuName))
                page = createPageChapter6();
            else if ("chapter7".Equals(topMenuName))
                page = createPageChapter7();
            else if ("chapter8".Equals(topMenuName))
                page = createPageChapter8();
            else if ("chapter9".Equals(topMenuName))
                page = createPageChapter9();
            else
            {
                MessageBox.Show("正在开发中......");
                return;
            }

            leftMenuFrame.Content = page;
        }


        private Page createPageChapter1()
        {
            MenuPageChapter1 page = new MenuPageChapter1();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter1_sy1"))
                {
                    contentFrame.Content = createPageChapter1_sy1();
                }
                else if (arg.Equals("chapter1_sy2"))
                {
                    contentFrame.Content = createPageChapter1_sy2();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter1_sy1();
                }

            });

            return page;
        }


        private Page createPageChapter1_sy1()
        {
            C1_SY1 page = new C1_SY1();
            return page;
        }

        private Page createPageChapter1_sy2()
        {
            C1_SY2 page = new C1_SY2();
            


            return page;
        }


        private Page createPageChapter6()
        {
            MenuPageChapter6 page = new MenuPageChapter6();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter6_sy1"))
                {
                    contentFrame.Content = createPageChapter6_sy1();
                }
                else if (arg.Equals("chapter6_sy2"))
                {
                    contentFrame.Content = createPageChapter6_sy2();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter6_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter6_sy1()
        {
            C6_SY1 page = new C6_SY1();
            return page;
        }

        private Page createPageChapter6_sy2()
        {
            C6_SY2 page = new C6_SY2();
            return page;
        }


        private Page createPageChapter7()
        {
            MenuPageChapter7 page = new MenuPageChapter7();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter7_sy1"))
                {
                    contentFrame.Content = createPageChapter7_sy1();
                }
                else if (arg.Equals("chapter7_sy2"))
                {
                    contentFrame.Content = createPageChapter7_sy2();
                }
                else if (arg.Equals("chapter7_sy3"))
                {
                    contentFrame.Content = createPageChapter7_sy3();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter7_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter7_sy1()
        {
            C7_SY1 page = new C7_SY1();
            return page;
        }

        private Page createPageChapter7_sy2()
        {
            C7_SY2 page = new C7_SY2();
            return page;
        }

        private Page createPageChapter7_sy3()
        {
            C7_SY3 page = new C7_SY3();
            return page;
        }

        private Page createPageChapter2()
        {
            MenuPageChapter2 page = new MenuPageChapter2();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter2_sy1"))
                {
                    contentFrame.Content = createPageChapter2_sy1();
                }
                else if (arg.Equals("chapter2_sy2"))
                {
                    contentFrame.Content = createPageChapter2_sy2();
                }
                else if (arg.Equals("chapter2_sy3"))
                {
                    contentFrame.Content = createPageChapter2_sy3();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter2_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter3()
        {
            MenuPageChapter3 page = new MenuPageChapter3();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter3_sy1"))
                {
                    contentFrame.Content = createPageChapter3_sy1();
                }
                else if (arg.Equals("chapter3_sy2"))
                {
                    contentFrame.Content = createPageChapter3_sy2();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter3_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter2_sy1()
        {
            C2_SY1 page = new C2_SY1(this);
            return page;
        }

        private Page createPageChapter2_sy2()
        {
            C2_SY2 page = new C2_SY2(this);
            page.NextEvent += ((object arg) =>
            {
                page.update(arg);
            });
            return page;
        }

        private Page createPageChapter2_sy3()
        {
            C2_SY3 page = new C2_SY3(this);
            return page;
        }

        private Page createPageChapter3_sy1()
        {
            C3_SY1 page = new C3_SY1(this);
            return page;
        }

        private Page createPageChapter3_sy2()
        {
            C3_SY2 page = new C3_SY2(this);
            return page;
        }


        private Page createPageChapter8()
        {
            MenuPageChapter8 page = new MenuPageChapter8();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter8_sy1"))
                {
                    contentFrame.Content = createPageChapter8_sy1();
                }
                else if (arg.Equals("chapter8_sy2"))
                {
                    contentFrame.Content = createPageChapter8_sy2();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter8_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter8_sy1()
        {
            C8_SY1 page = new C8_SY1(this);
            return page;
        }

        private Page createPageChapter8_sy2()
        {
            C8_SY2 page = new C8_SY2(this);
            return page;
        }


        private Page createPageChapter9()
        {
            MenuPageChapter9 page = new MenuPageChapter9();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("chapter9_sy1"))
                {
                    contentFrame.Content = createPageChapter9_sy1();
                }
                else if (arg.Equals("chapter9_sy2"))
                {
                    contentFrame.Content = createPageChapter9_sy2();
                }
                else if (arg.Equals("chapter9_sy3"))
                {
                    contentFrame.Content = createPageChapter9_sy3();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageChapter9_sy1();
                }

            });

            return page;
        }

        private Page createPageChapter9_sy1()
        {
            FileListPage page = new FileListPage();
            return page;
        }

        private Page createPageChapter9_sy2()
        {
            RoomTypeListPage page = new RoomTypeListPage();
            return page;
        }

        private Page createPageChapter9_sy3()
        {
            ADOTest page = new ADOTest(this);
            return page;
        }

        private Page createPageIndex()
        {
            MenuPageIndex page = new MenuPageIndex();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("index_jz"))
                {
                    contentFrame.Content = createPageIndex_Jz();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageIndex_Jz();
                }
                /*
                else if (arg.Equals("index_sbdss"))
                {
                    contentFrame.Content = createPageIndex_sbdss() 
                }
                else if (arg.Equals("index_hss"))
                {
                    contentFrame.Content = createPageIndex_hss() 
                }
                else if (arg.Equals("index_hfw"))
                {
                    contentFrame.Content = createPageIndex_hfw() 
                }
                else if (arg.Equals("index_shdw"))
                {
                    contentFrame.Content = createPageIndex_shdw();
                }
                else if (arg.Equals("index_shry"))
                {
                    contentFrame.Content = createPageIndex_shry();
                }
                 * */

            });

            return page;
        }


        private Page createPageIndex_Jz()
        {
            JzListPage page = new JzListPage();
            return page;

        }


        private Page createPageFgbz()
        {
            MenuPageChapter9 page = new MenuPageChapter9();
            page.NextEvent += ((object arg) =>
            {
                if (arg.Equals("fgbz_fg"))
                {
                    contentFrame.Content = createPageFgbz_fg();
                }
                else
                {
                    MessageBox.Show("正在开发中......");
                    contentFrame.Content = createPageFgbz_fg();
                }
                /*
                else if (arg.Equals("index_sbdss"))
                {
                    contentFrame.Content = createPageIndex_sbdss() 
                }
                else if (arg.Equals("index_hss"))
                {
                    contentFrame.Content = createPageIndex_hss() 
                }
                else if (arg.Equals("index_hfw"))
                {
                    contentFrame.Content = createPageIndex_hfw() 
                }
                else if (arg.Equals("index_shdw"))
                {
                    contentFrame.Content = createPageIndex_shdw();
                }
                else if (arg.Equals("index_shry"))
                {
                    contentFrame.Content = createPageIndex_shry();
                }
                 * */

            });

            return page;
        }


        private Page createPageFgbz_fg()
        {
            FileListPage page = new FileListPage();
            return page;
        }
    }

    

     
}
