using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SQLite;

namespace CBusNoti
{
    public partial class Form1 : Form
    {
        private string m_key = "JRRPdUC9vWuhClKYevyLIswz3UA5KYf30RRXYA8/z2S8ktyFdBb+4CmSZsA+HT3LXtvOgZWEj4KGODX3d3Hfkg==";
        private string m_strRouteId;
        private string m_strStationId;
        private bool m_bAlert = false;
        private int m_nAlertTime;
        static Timer tm = new Timer();

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int n, int m);  

        public Form1()
        {
            InitializeComponent();
        }

        private void SetData()
        {
            m_strRouteId = this.tb_busno.Text;
            m_strStationId = this.tb_busstop.Text;
            
            if (string.IsNullOrEmpty(m_strRouteId))
            {
                m_strRouteId = "216000046";     
                m_strStationId = "116000013";
            }
        }

        private void bt_apply_Click(object sender, EventArgs e)
        {
            SetData();


            string strUrl = "http://openapi.gbis.go.kr/ws/rest/busarrivalservice?serviceKey=" + m_key + "&routeId=" + m_strRouteId + "&stationId=" + m_strStationId;

            try
            {
                string strXML = CXMLProc.GetRequestWeb(strUrl, Encoding.UTF8);

                Dictionary<string, string> dcHead = CXMLProc.ParseXMLForDic(strXML, "msgHeader");

                string strQeuryTime = "";
                string strDelay1 = "";
                string strDelay2 = "";
                string strEnd = "";
                string strFlag = "";
                string strLoc1 = "";
                string strLoc2 = "";
                string strLow1 = "";
                string strLow2 = "";
                string strBusNo1 = "";
                string strBusNo2 = "";
                string strWaitTime1 = "";
                string strWaitTime2 = "";
                int nWaitTime1 = 100;

                if (dcHead != null)
                {
                    //
                    if (dcHead["resultCode"].Equals("0"))
                    {
                        strQeuryTime = dcHead["queryTime"];

                        this.lb_querytime.Text = strQeuryTime.Substring(0, 19);

                        Dictionary<string, string> dcBody = CXMLProc.ParseXMLForDic(strXML, "busArrivalItem");

                        if (dcBody != null)
                        {
                            strDelay1 = dcBody["delayYn1"];
                            strDelay2 = dcBody["delayYn2"];
                            strEnd = dcBody["drvEnd"];
                            strFlag = dcBody["flag"];
                            strLoc1 = dcBody["locationNo1"];
                            strLoc2 = dcBody["locationNo2"];
                            strLow1 = dcBody["lowPlate1"];
                            strLow2 = dcBody["lowPlate2"];
                            strBusNo1 = dcBody["plateNo1"];
                            strBusNo2 = dcBody["plateNo2"];
                            strWaitTime1 = dcBody["predictTime1"];
                            strWaitTime2 = dcBody["predictTime2"];

                            nWaitTime1 = Int32.Parse(strWaitTime1);

                            string strTxt1= "";
                            strTxt1 += "(" + strBusNo1;
                            if ( strLow1.Equals("1"))
                            {
                                strTxt1 += "[저상]";
                            }
                            strTxt1 += ")";

                            if ( strDelay1.Equals("Y"))
                            {   
                                strTxt1 +=  " 회차점 대기중 ";
                            }
                            else 
                            {
                               strTxt1 +=  " " + strLoc1 + "전 " + strWaitTime1 + "분 후 도착";
                            }
                            

                            string strTxt2= "";
                            strTxt2 += "(" + strBusNo2;
                            if ( strLow2.Equals("1"))
                            {
                                strTxt2 += "[저상]";
                            }
                            strTxt2 += ")";

                            if ( strDelay2.Equals("Y"))
                            {   
                                strTxt2 +=  " 회차점 대기중 ddddddddddddddddddddddddddfghfghfghddddddddddddddddddddddddd  dd";
                            }
                            else 
                            {
                                strTxt2 += " " + strLoc2 + "전 " + strWaitTime2 + "분 후 도착";
                            }


                            this.lb_view.Text = strTxt1;
                            this.lb_view2.Text = strTxt2;

                            // 알림 확인
                            if (strDelay1.Equals("N") && m_nAlertTime >= nWaitTime1)
                            {
                                if(tm.Enabled) tm.Stop();

                                Beep(512, 1000);
                                Console.WriteLine("\a");

                                Noti.NotiForm frmNoti = new Noti.NotiForm();
                                string strMsg = " 버스온다!!! < " + nWaitTime1.ToString() + "분 후 도착 >";
                                frmNoti.setNotiText(strMsg);
                                frmNoti.ShowDialog();
                                
                                //
                                //int sw = Screen.PrimaryScreen.WorkingArea.Width;
                                //int sh = Screen.PrimaryScreen.WorkingArea.Height;
                                

                                //MessageBox.Show(" 버스온다!!! < " + nWaitTime1.ToString() + "분 후 도착 >");

                            }
                        }
                        else
                        {
                            this.lb_view.Text = "데이터 없음!!";
                        }


                    }
                    else
                    {
                        this.lb_view.Text = "서버연결 실패!!";
                    }
                }
                else
                {
                    this.lb_view.Text = "서버연결 실패!!";
                }
            }
            catch (Exception ex)
            {
                this.lb_view.Text = "<<< ERROR 발생 >>>  " + ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tm.Enabled) tm.Stop();

             m_nAlertTime = Int32.Parse(this.noti_min.Value.ToString());

            if (m_nAlertTime == 0)
            {
                MessageBox.Show("버스 도착전 알림시간을 설정하세요.");
                return;
            }


            if (!m_bAlert)
            {
                m_bAlert = true;
                this.lb_content.Text = "버스 도착 " + m_nAlertTime.ToString() + "분전 알림 기능이 시작되었습니다.";
                bt_alert.Text = "알림 정지";

                CheckAlert(m_nAlertTime, 1);
            }
            else
            {
                m_bAlert = false;
                this.lb_content.Text = "내용 알림";
                bt_alert.Text = "알림 시작";
            }
        }


        private bool CheckAlert(int nAlertTime, int nGapSec)
        {
            bool bReturn = false;

            tm.Interval = nGapSec * 1000;    // 초
            tm.Tick += new EventHandler(bt_apply_Click);
            tm.Start();


            return bReturn;
        }

        private void nt_icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // 기본데이터 수신 DB 넣기

            SQLiteConnection.CreateFile("test.db");

            using (var conn = new SQLiteConnection("Data Source=test.db"))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "CREATE TABLE tb_test(value text, size bigint);";
                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO tb_test VALUES(?,?);";
                        SQLiteParameter param1 = new SQLiteParameter();
                        SQLiteParameter param2 = new SQLiteParameter();

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);

                        param1.Value = "1";
                        param2.Value = 2;
                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * from tb_test where size >= 2 and size <= 2 order by Size;";
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                            {
                                Console.WriteLine("{0}, {1}", reader.GetString(0), reader.GetInt64(1));
                            }
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

        }


        private void getBaseDatabaseRead()
        {

            // CREATE table 
            SQLiteConnection.CreateFile("BUSNOTI.db");

            using (var conn = new SQLiteConnection("Data Source=BUSNOTI.db"))
            {
                conn.Open();
                try
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "CREATE TABLE tb_baseinfo (url text, ver text, regdate datetime);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE tb_area (center_id text, area_id text, area_name text);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE tb_route (center_id text, area_id text, area_name text);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE tb_routeline (center_id text, area_id text, area_name text);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE tb_route_station (center_id text, area_id text, area_name text);";
                        cmd.ExecuteNonQuery();
                    
                        cmd.CommandText = "CREATE TABLE tb_station (center_id text, area_id text, area_name text);";
                        cmd.ExecuteNonQuery();
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }


            // 기반 데이터 url
            string strBaseUrl = "http://openapi.gbis.go.kr/ws/rest/baseinfoservice?serviceKey=" + m_key;

            try
            {
                string strXML = CXMLProc.GetRequestWeb(strBaseUrl, Encoding.UTF8);

                Dictionary<string, string> dcHead = CXMLProc.ParseXMLForDic(strXML, "msgHeader");

                string strQeuryTime = "";
                string strAreaUrl = "";
                string strAreaVer = "";
                string strRouteUrl = "";
                string strRouteVer = "";
                string strRouteLineUrl = "";
                string strRouteLineVer = "";
                string strRouteStationUrl = "";
                string strRouteStationVer = "";
                string strStationUrl = "";
                string strStationVer = "";
                
                if (dcHead != null)
                {
                    if (dcHead["resultCode"].Equals("0"))   // 정상 처리
                    {
                        strQeuryTime = dcHead["queryTime"];     // 처리 시간

                        // strQeuryTime.Substring(0, 19);

                        Dictionary<string, string> dcBody = CXMLProc.ParseXMLForDic(strXML, "baseInfoItem");

                        if (dcBody != null)
                        {
                            strAreaUrl = dcBody["areaDownloadUrl"];
                            strAreaVer = dcBody["areaVersion"];
                            strRouteUrl = dcBody["routeDownloadUrl"];
                            strRouteVer = dcBody["routeVersion"];
                            strRouteLineUrl = dcBody["routeLineDownloadUrl"];
                            strRouteLineVer = dcBody["routeLineVersion"];
                            strRouteStationUrl = dcBody["routeStationDownloadUrl"];
                            strRouteStationVer = dcBody["routeStationVersion"];
                            strStationUrl = dcBody["stationDownloadUrl"];
                            strStationVer = dcBody["stationVersion"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        
    }
}
