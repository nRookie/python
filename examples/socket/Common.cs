using System;
using System.Collections.Generic;
using System.Text;
using AQUA.MeasureInstrument;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace AQUA
{
    //どこからでも参照できる共通設定
    public static class CommonSetting
    {
        //対応モジュール。ここに書いた名前とコンフィグレーションファイルに記載されている
        //モジュール名が一致しないと警告を出す
        public static string[] TARGET_MODULE = new string[] { "Type1WP" };

        //ディレクトリパス (パスには最後の￥を含む)            
        public static string PATH_EXE;              //exeの場所
        public static string PATH_ROOT;             //ルートフォルダ
        public static string PATH_WAVEFORM;         //ウェブフォームの保存先フォルダ
        public static string PATH_CABLELOSS;        //ケーブルロスフォルダ
        public static string PATH_MODULESCRIPT;     //モジュールスクリプトフォルダ

        //ファイルパス
        public static string PATH_FILE_PATH;            // パス設定ファイル
        public static string PATH_FILE_SYSTEM;          // システムファイル
        public static string PATH_FILE_INSTRUMENT;      // 測定器設定ファイル
        public static string PATH_FILE_ENVIRONMENT;     // 環境ファイル
        public static string PATH_FILE_GAMEN;           // 画面設定ファイル
        public static string PATH_FILE_MASK;            // マスクファイル
        public static string PATH_FILE_ADDRESS;         // ローカルアドレスファイル
        public static string PATH_FILE_SERIAL;          // シリアル番号ファイル
        public static string PATH_FILE_UNIT;            // 単位ファイル
        public static string PATH_FILE_AUTORANGE;       // AutoRangeファイル
        public static string PATH_FILE_LAUNCHER;        // Launcherファイル

        public static string LOT_ID;                //ロットID
        public static string LINE_NAME;             //ライン名
        public static string HEAD_NAME;             //ヘッド名

    }

    //pingpong用
    public static class PingPong
    {
        //public static int N4010A_VISA_FLAG = 0; // LockStateControl = 1 / normal = 0
        public static int N4010A_VISA_FLAG = 0; //pingpong lock = 2 / unlock = 1 / pingpon nashi = 0
        public static string N4010A_VISA_UDP = "";  // 
        public static string N4010A_VISA_UDP_PORT = ""; // 
        public static string N4010A_LSC_NAME = "";
    }

    //Factory用
    public static class CommonFactory
    {
        public static bool FactoryEnable = false;       //2012/03/14追加 ONにすると、立ち上げ時チェックが入る
        public static string FactoryName = "";
        public static string SystemID = "";
        public static string ServerIP = "";
        public static string ServerPort = "";
        public static string TimeOut = "";
        public static string BusyWait = "";
        public static string NumberFolder = "";         //2012/03/14追加
        public static string NumberHead = "";           //仮MACの先頭アドレス
    }

    //DIO用 
    public static class DIO
    {
        public static Cdio_KMC mDio;
        public static MeasInfo.MeasMode MeasMode;
    }

    public static class CommonAyla
    {
        public static string email = "";
        public static string pass = "";
        public static string access_token = "";
        public static string model = "";
        public static string dsn = "";
        public static string public_key = "";
  
    }
    //共通定数クラス
    //このクラス内で宣言された定数はnamespace AQUA内の全クラス
    //で使用できる。
    // 2008/08/27 tanaka
    public static class Common
    {
        //--- 共通定数 ---------------------------------------------
        //全体で使えるような定数はここに入れてください。
        //個々の案件でやむを得ず使用する共通定数は別にstatic classを作って管理して下さい
        //数字を直打ちするより、なるべくここにある定数を使ってください
        //
        //ここで作った定数を使う場合は、定数名がXXXの場合、
        //Common.XXX;
        //と、このクラス名.定数名 で使ってください。
        //
        //public で宣言する

        //名前
        //Properties\AssemblyInfo.cs 内の [assembly: AssemblyProduct("****")] に記述する
        //プログラム内からは Application.ProductName を使用する
        //public const string ApplicationName = "Aqua II (moyashi)";

        //バージョン
        //Properties\AssemblyInfo.cs 内の [assembly: AssemblyVersion("*.*.*.*")] に記述する
        //変更履歴は、変更履歴.txtに記述する
        //プログラム内からは Common.ApplicationVersion を使用する
        //Application.ProductVersion の後は亜種など特例に使う(例 " with Tuner", ".α" など)
        public static string ApplicationVersion = "Ver " + Application.ProductVersion + "";
        public const string AquaVersion = "Ver 2.0.7.2";

        //OS
        public enum OS
        {
            Other = 0,
            Win95,
            Win98,
            WinMe,
            WinNT3x,
            WinNT4,
            Win2000,
            WinXP,
            WinServer2003,
            WinVista,
            Win7
        }

        //戻り値
        public const int AQUA_INIT = 0;
        public const int AQUA_SUCCESS = 1;
        public const int AQUA_EXIT = 2;
        public const int AQUA_PASS = 1;
        public const int AQUA_FAIL = -1;
        public const int AQUA_ERROR = -2;
        public const int AQUA_ABORT = -3;
        public const int AQUA_ANOTHER = -4;

        //単位系
        public const double NANO = 0.000000001;
        public const double MICRO = 0.000001;
        public const double MIRI = 0.001;
        public const int KIRO = 1000;
        public const int MEGA = 1000000;
        public const long GIGA = 1000000000;

        public const int KHZ = 1000;
        public const int MHZ = 1000000;
        public const long GHZ = 1000000000;

        //ログ出力
        public const uint LogCategory_Comment = 0x1;        // Log分類コード コメント出力
        public const uint LogCategory_Error = 0x2;          // Log分類コード エラー
        public const uint LogCategory_Target = 0x4;         // Log分類コード モジュール制御
        public const uint LogCategory_Instrument = 0x8;     // Log分類コード 測定器制御
        public const uint LogCategory_GPIB = 0x8000000;     // Log分類コード I/F GPIB
        public const uint LogCategory_LAN = 0x10000000;     // Log分類コード I/F LAN
        public const uint LogCategory_UDP = 0x20000000;     // Log分類コード I/F UDP
        public const uint LogCategory_VISA = 0x40000000;    // Log分類コード I/F VISA
        public const uint LogCategory_COM = 0x80000000;     // Log分類コード I/F COM
        public const int LogGroup_Disable = -1;         // Logグループコード 出力禁止
        public const int LogGroup_Default = 0;          // Logグループコード デフォルト

        //--(定数　ここまで)-------------------------------------

        //--- 共通変数 ------------------------------------------
		public static string DUT_Macaddress = "";                  //DB用に保持MAC
        public static string DUT_BDaddress = "";                   //DB用に保持BD
        public static string DUT_2DCODE = "";                      //DB用に保持2DCode
        public static bool DUT_2DCODE_READ_FLG = false;            //DB用に保持2Dを読んだかどうかのフラグ(one time)
        public static string DUT_CERTIFICATE_PATH = "";            //DB用 PRASSからの証明書ファイルのパスをセットします
        public static string PRASS_MSG = "";                       //DB用 PRASSからのエラーメッセージをセットします
        public static string PRASS_CODE = "";                      //DB用 PRASSからのエラーコードをセットします
        public static string PRASS_RETESTCOUNT = "";               //DB用 PRASSからの再測定カウントをセットします
        public static string DUT_SSID = "";
        public static string DUT_KEY = "";

		//HTTP PRASS系 引数
        public static int LOTNOCHECKFLAG = 0;
        public static int CHECKINOUTFLAG = 0;
        public static int REJECTFLAG = 0;
        public static int POORBWFLAG = 0;
        public static int PROCESSISSUEBWFLAG = 0;
        public static int PROCESSFAILUREFLAG = 0;
        public static int TESTHISFLAG = 0;
        public static int FLAG1ST = 0;
        public static int FINALFAILUREFLAG = 0;
        public static int MISSINGPCBWFLAG = 0;

        public static bool ExitThreadFig = false;                   //http通信スレッド終了フラグ
        public static long processflag = 0; //0: BTシーケンス測定なし 1: BTシーケンス測定開始 2: BTシーケンス測定中
        public static bool measTimeLogFlag = false;
        public static bool timeoutflag = false;
        public static bool Imp_update_skip = false; //Imp用OTP書き込みフラグ
        public static bool one_time_run_flg = true; //Imp用初回のみ実行フラグ
        public static bool ayla_serial_write_skip = false; //Ayla用serial書き込みフラグ
        public static string ayla_serial = "";//Ayla用serial,Skip時保存用
        public static bool ayla_relabel = false; //Ayla用

        public static OS GetOS()
        {
            OS mOS = OS.Other;
            System.OperatingSystem os = System.Environment.OSVersion;
            switch (os.Platform)
            {
                case System.PlatformID.Win32Windows:

                    if (os.Version.Major >= 4)
                    {
                        switch (os.Version.Minor)
                        {
                            case 0:
                                mOS = OS.Win95;
                                break;
                            case 10:
                                mOS = OS.Win98;
                                break;
                            case 90:
                                mOS = OS.WinMe;
                                break;
                        }
                    }
                    break;
                case System.PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3:
                            mOS = OS.WinNT3x;
                            break;
                        case 4:
                            if (os.Version.Minor == 0)
                            {
                                mOS = OS.WinNT4;
                            }
                            break;
                        case 5:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    mOS = OS.Win2000;
                                    break;
                                case 1:
                                    mOS = OS.WinXP;
                                    break;
                                case 2:
                                    mOS = OS.WinServer2003;
                                    break;
                            }
                            break;
                        case 6:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    mOS = OS.WinVista;
                                    break;
                                case 1:
                                    mOS = OS.Win7;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return (mOS);
        }
        //ネットワークのIPとステータスを取得する
        public static List<Network_struct> GetNetwork()
        {
            List<Network_struct> nstruct = new List<Network_struct>();
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nis)
            {
                Network_struct mnet = new Network_struct();
                IPInterfaceProperties ip_prop = adapter.GetIPProperties();

                // ユニキャスト IP アドレスの取得
                UnicastIPAddressInformationCollection addrs = ip_prop.UnicastAddresses;
                foreach (UnicastIPAddressInformation addr in addrs)
                {
                    mnet.dip = addr.Address.ToString();
                    mnet.dstatus = adapter.OperationalStatus;
                    nstruct.Add(mnet);
                }
            }
            return nstruct;
        }
        //---(関数　ここまで）------------------------------------
    }

    /// <summary>
    ///  エラーチェッククラス
    /// </summary>
    public sealed class Validation
    {
        public enum SEL_INT_HEX
        {
            INT = 0,
            HEX = 1
        }

        #region 設定ファイルから読み込んだパラメータの型範囲チェック
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  int型 : 設定ファイルから読み込んだパラメータのチェック/変換 
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out int ret_val, string str_min, string str_max, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = 9999;
            err_msg = "";

            res = isValidInt(param, out ret_val, str_min, str_max, out err_msg);
            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  int型(16進数 選択可): 設定ファイルから読み込んだパラメータのチェック/変換
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <param name="sel">10進のとき: Validation.SEL_INT_HEX.INT, 16進("0x**"の形): Validation.SEL_INT_HEX.HEX を選択</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out int ret_val, string str_min, string str_max, string param_name, out string err_msg, Validation.SEL_INT_HEX sel)
        {
            long res = Common.AQUA_ERROR;

            ret_val = 9999;
            err_msg = "";

            //普通の数字の場合
            if (sel == SEL_INT_HEX.INT)
            {
                res = isValidInt(param, out ret_val, str_min, str_max, out err_msg);
            }
            //16進数の場合
            else if (sel == SEL_INT_HEX.HEX)
            {
                res = isValidHex(param, out ret_val, str_min, str_max, out err_msg);
            }
            else
            {
                err_msg = "プログラムエラー selに与える引数が違います";
                res = Common.AQUA_ERROR;
            }

            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long型 : 設定ファイルから読み込んだパラメータのチェック/変換
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out long ret_val, string str_min, string str_max, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = 9999;
            err_msg = "";

            res = isValidLong(param, out ret_val, str_min, str_max, out err_msg);
            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long型(16進数 選択可): 設定ファイルから読み込んだパラメータのチェック/変換
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <param name="sel">10進のとき: Validation.SEL_INT_HEX.INT, 16進("0x**"の形): Validation.SEL_INT_HEX.HEX を選択</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out long ret_val, string str_min, string str_max, string param_name, out string err_msg, Validation.SEL_INT_HEX sel)
        {
            long res = Common.AQUA_ERROR;

            ret_val = 9999;
            err_msg = "";

            //普通の数字の場合
            if (sel == SEL_INT_HEX.INT)
            {
                res = isValidLong(param, out ret_val, str_min, str_max, out err_msg);
            }
            //16進数の場合
            else if (sel == SEL_INT_HEX.HEX)
            {
                res = isValidHex(param, out ret_val, str_min, str_max, out err_msg);
            }
            else
            {
                err_msg = "プログラムエラー selに与える引数が違います";
                res = Common.AQUA_ERROR;
            }

            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  double型 : 設定ファイルから読み込んだパラメータのチェック/変換 (実数)
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときdouble型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out double ret_val, string str_min, string str_max, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = 9999.9999;
            err_msg = "";

            res = isValidDouble(param, out ret_val, str_min, str_max, out err_msg);
            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  string型 : 設定ファイルから読み込んだパラメータのチェック/変換 (長さチェック)
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときparamと同じの文字列が返る</param>
        /// <param name="str_min">最小長さ(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大長さ(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out string ret_val, string str_min, string str_max, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = "NG";
            err_msg = "";

            res = isValidString(param, str_min, str_max, out err_msg);

            if (res == Common.AQUA_SUCCESS)
            {
                ret_val = param;
            }
            else
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  string型 : 設定ファイルから読み込んだパラメータのチェック/変換 (一致チェック)
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときparamと同じの文字列が返る</param>
        /// <param name="str_cmps">一致を比較する文字列の配列 (例： new string[] {"ON, "OFF"} ）</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out string ret_val, string[] str_cmps, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = "NG";
            err_msg = "";

            res = isValidString(param, str_cmps, out err_msg);
            if (res == Common.AQUA_SUCCESS)
            {
                ret_val = param;
            }
            else
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  bool型 : 設定ファイルから読み込んだパラメータのチェック/変換
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <param name="str_true">True と判断する文字列</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out bool ret_val, string str_false, string str_true, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = false;
            err_msg = "";

            res = isValidBool(param, out ret_val, str_false, str_true, out err_msg);
            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  bool型 : 設定ファイルから読み込んだパラメータのチェック/変換
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="int_false">False と判断する数値</param>
        /// <param name="int_true">True と判断する数値</param>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out bool ret_val, int int_false, int int_true, string param_name, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ret_val = false;
            err_msg = "";

            res = isValidBool(param, out ret_val, int_false, int_true, out err_msg);
            if (res != Common.AQUA_SUCCESS)
            {
                //エラーメッセージにパラメータ名を追加
                err_msg = "パラメータ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        #endregion

        #region 真偽の数値チェック(bool型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の文字列チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <param name="str_true">True と判断する文字列</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, string str_false, string str_true, out string err_msg)
        {
            long res = Common.AQUA_ERROR;

            err_msg = "";
            ret_val = false;

            //nullチェック
            if (param == null)
            {
                err_msg = "値を入れてください";
                return Common.AQUA_ERROR;
            }

            res = Common.AQUA_SUCCESS;
            if (param == str_true) { ret_val = true; }
            else if (param == str_false) { ret_val = false; }
            else
            {
                err_msg = str_true + " または " + str_false + "を指定してください";
                res = Common.AQUA_ERROR;
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の文字列チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <param name="str_true">True と判断する文字列</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, string str_false, string str_true)
        {
            string dummy;
            return isValidBool(param, out ret_val, str_false, str_true, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の文字列チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <param name="str_true">True と判断する文字列</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, string str_false, string str_true, out string err_msg)
        {
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, str_false, str_true, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の文字列チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <param name="str_true">True と判断する文字列</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, string str_false, string str_true)
        {
            string str_dummy;
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, str_false, str_true, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の数値チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="int_false">False と判断する数値</param>
        /// <param name="int_true">True と判断する数値</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, int int_false, int int_true, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_param;
            err_msg = "";
            ret_val = false;

            //nullチェック
            if (param == null)
            {
                err_msg = "値を入れてください";
                return Common.AQUA_ERROR;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out int_param))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (int_param == int_true)
                {
                    ret_val = true;
                    res = Common.AQUA_SUCCESS;
                }
                else if (int_param == int_false)
                {
                    ret_val = false;
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                err_msg = int_true + " または " + int_false + "を指定してください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の数値チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときbool型の値が返る</param>
        /// <param name="int_false">False と判断する数値</param>
        /// <param name="int_true">True と判断する数値</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, int int_false, int int_true)
        {
            string dummy;
            return isValidBool(param, out ret_val, int_false, int_true, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の数値チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="int_false">False と判断する数値</param>
        /// <param name="int_true">True と判断する数値</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, int int_false, int int_true, out string err_msg)
        {
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, int_false, int_true, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  真偽の数値チェック
        /// </summary>
        /// <param name="int_false">False と判断する数値</param>
        /// <param name="int_true">True と判断する数値</param>
        /// <param name="str_false">False と判断する文字列</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, int int_false, int int_true)
        {
            string str_dummy;
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, int_false, int_true, out str_dummy);
        }

        #endregion

        #region 整数の型チェック(int型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val >= int_min && ret_val <= int_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "")
                {
                    tmp += "の";
                }
                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidInt(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, string str_min, string str_max, out string err_msg)
        {
            int int_dummy;
            return isValidInt(param, out int_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, string str_min, string str_max)
        {
            string str_dummy;
            int int_dummy;
            return isValidInt(param, out int_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val < int_min || ret_val > int_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidIntInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            int int_dummy;

            return isValidIntInv(param, out int_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, string str_min, string str_max, out string err_msg)
        {
            int int_dummy;

            return isValidIntInv(param, out int_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 整数の型チェック(uint型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときuint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, out uint ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            uint uint_min;
            uint uint_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!uint.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out uint_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_min = uint.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!uint.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out uint_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_max = uint.MaxValue;
            }

            if (uint.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val >= uint_min && ret_val <= uint_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "")
                {
                    tmp += "の";
                }
                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときuint型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, out uint ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUint(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, string str_min, string str_max, out string err_msg)
        {
            uint uint_dummy;
            return isValidUint(param, out uint_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, string str_min, string str_max)
        {
            string str_dummy;
            uint uint_dummy;
            return isValidUint(param, out uint_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときuint型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, out uint ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            uint uint_min;
            uint uint_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!uint.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out uint_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_min = uint.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!uint.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out uint_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_max = uint.MaxValue;
            }

            if (uint.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val < uint_min || ret_val > uint_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときuint型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, out uint ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUintInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            uint uint_dummy;

            return isValidUintInv(param, out uint_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, string str_min, string str_max, out string err_msg)
        {
            uint uint_dummy;

            return isValidUintInv(param, out uint_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 整数の型チェック(short型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときshort型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, out short ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            short short_min;
            short short_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!short.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out short_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_min = short.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!short.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out short_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_max = short.MaxValue;
            }

            if (short.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val >= short_min && ret_val <= short_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "")
                {
                    tmp += "の";
                }
                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときshort型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, out short ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidShort(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, string str_min, string str_max, out string err_msg)
        {
            short short_dummy;
            return isValidShort(param, out short_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, string str_min, string str_max)
        {
            string str_dummy;
            short short_dummy;
            return isValidShort(param, out short_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときshort型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, out short ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            short short_min;
            short short_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!short.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out short_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_min = short.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!short.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out short_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_max = short.MaxValue;
            }

            if (short.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val < short_min || ret_val > short_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときshort型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, out short ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidShortInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            short short_dummy;

            return isValidShortInv(param, out short_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, string str_min, string str_max, out string err_msg)
        {
            short short_dummy;

            return isValidShortInv(param, out short_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 整数の型チェック(ushort型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときushort型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, out ushort ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ushort ushort_min;
            ushort ushort_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!ushort.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out ushort_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_min = ushort.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!ushort.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out ushort_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_max = ushort.MaxValue;
            }

            if (ushort.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val >= ushort_min && ret_val <= ushort_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "")
                {
                    tmp += "の";
                }
                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときushort型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, out ushort ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUshort(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, string str_min, string str_max, out string err_msg)
        {
            ushort ushort_dummy;
            return isValidUshort(param, out ushort_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, string str_min, string str_max)
        {
            string str_dummy;
            ushort ushort_dummy;
            return isValidUshort(param, out ushort_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときushort型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, out ushort ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ushort ushort_min;
            ushort ushort_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!ushort.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out ushort_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_min = ushort.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!ushort.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out ushort_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_max = ushort.MaxValue;
            }

            if (ushort.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val < ushort_min || ret_val > ushort_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときushort型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, out ushort ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUshortInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            ushort ushort_dummy;

            return isValidUshortInv(param, out ushort_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, string str_min, string str_max, out string err_msg)
        {
            ushort ushort_dummy;

            return isValidUshortInv(param, out ushort_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 整数の型チェック(long型)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            if (long.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val >= lng_min && ret_val <= lng_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "") 
                { 
                    tmp += "の"; 
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, string str_min, string str_max)
        {
            string str_dummy;
            long lng_dummy;

            return isValidLong(param, out lng_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, string str_min, string str_max, out string err_msg)
        {
            long lng_dummy;
            return isValidLong(param, out lng_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidLong(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            if (long.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = 前後の空白,前の符号のみを許可
                if (ret_val < lng_min || ret_val > lng_max)
                {
                    res = Common.AQUA_SUCCESS;
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidLongInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            long lng_dummy;

            return isValidLongInv(param, out lng_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, string str_min, string str_max, out string err_msg)
        {
            long lng_dummy;
            return isValidLongInv(param, out lng_dummy, str_min, str_max, out err_msg);
        }
        #endregion

        #region 小数の型チェック(double型)
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときdouble型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, out double ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            double dbl_min;
            double dbl_max;

            err_msg = "";
            ret_val = 9999.9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!double.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out dbl_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_min = double.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!double.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out dbl_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_max = double.MaxValue;
            }

            //無限や非数値("NaN")を表わす文字でないかチェック(これらはTryParseを通ってしまう)
            //数値と.以外が含まれる書式でないかチェック
            if (param != System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NaNSymbol)
            {
                if (double.TryParse(param, System.Globalization.NumberStyles.Float, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.Float = 前後の空白、前の符号、小数点、指数表記のみ許可
                    if (ret_val >= dbl_min && ret_val <= dbl_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999.9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "") 
                { 
                    tmp += "の"; 
                }

                err_msg = tmp + "数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときdouble型の値が返る</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, out double ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidDouble(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, string str_min, string str_max)
        {
            string str_dummy;
            double dbl_dummy;
            return isValidDouble(param, out dbl_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, string str_min, string str_max, out string err_msg)
        {
            double dbl_dummy;
            return isValidDouble(param, out dbl_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときdouble型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, out double ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            double dbl_min;
            double dbl_max;

            err_msg = "";
            ret_val = 9999.9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!double.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out dbl_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_min = double.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!double.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out dbl_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_max = double.MaxValue;
            }

            //無限や非数値("NaN")を表わす文字でないかチェック(これらはTryParseを通ってしまう)
            //数値と.以外が含まれる書式でないかチェック
            if (param != System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NaNSymbol)
            {
                if (double.TryParse(param, System.Globalization.NumberStyles.Float, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.Float = 前後の空白、前の符号、小数点、指数表記のみ許可
                    if (ret_val < dbl_min || ret_val > dbl_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999.9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときdouble型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, out double ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidDoubleInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, string str_min, string str_max)
        {
            string str_dummy;
            double dbl_dummy;
            return isValidDoubleInv(param, out dbl_dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  実数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, string str_min, string str_max, out string err_msg)
        {
            double dbl_dummy;
            return isValidDoubleInv(param, out dbl_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 16進数の型チェック("0x**"の形)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  16進int整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "0xで始まる16進整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            //"0x"ではじまって無ければエラー
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"を除去したものを数値に直す
                if (int.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-fを許可。"0x"は不許可。
                    if (ret_val >= int_min && ret_val <= int_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "") 
                { 
                    tmp += "の"; 
                }

                err_msg = tmp + "0xで始まる16進整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進int整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHex(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, string str_min, string str_max)
        {
            long dummy;
            string str_dummy;
            return isValidHex(param, out dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  16進整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, string str_min, string str_max, out string err_msg)
        {
            long dummy;
            return isValidHex(param, out dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  16進long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "0xで始まる16進整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            //"0x"ではじまって無ければエラー
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"を除去したものを数値に直す
                if (long.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-fを許可。"0x"は不許可。
                    if (ret_val >= lng_min && ret_val <= lng_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "")
                {
                    tmp += str_min + "以上";
                }
                if (str_max != "")
                {
                    tmp += str_max + "以下";
                }
                if (tmp != "") 
                {
                    tmp += "の";
                }

                err_msg = tmp + "0xで始まる16進整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進long整数の範囲チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">10進数最小値(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大値(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHex(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進int整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "0xで始まる16進整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            //"0x"ではじまって無ければエラー
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"を除去したものを数値に直す
                if (int.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-fを許可。"0x"は不許可。
                    if (ret_val < int_min || ret_val > int_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "16進整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進int整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときint型の値が返る</param>
        /// <param name="str_min">10進数最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHexInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">10進数最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, string str_min, string str_max)
        {
            int dummy;
            string str_dummy;
            return isValidHexInv(param, out dummy, str_min, str_max, out str_dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進int整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="str_min">最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, string str_min, string str_max, out string err_msg)
        {
            int dummy;
            return isValidHexInv(param, out dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">10進数最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //nullチェック
            if (param == null)
            {
                err_msg = "0xで始まる16進整数値を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            //"0x"ではじまって無ければエラー
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"を除去したものを数値に直す
                if (long.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-fを許可。"0x"は不許可。
                    if (ret_val < lng_min || ret_val > lng_max)
                    {
                        res = Common.AQUA_SUCCESS;
                    }
                }
            }

            if (res == Common.AQUA_ERROR)
            {
                ret_val = 9999;

                string tmp = "";
                if (str_min != "" && str_max != "")
                {
                    tmp += str_min + "未満、または" + str_max + "より大きい";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "未満の";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "より大きい";
                }

                err_msg = tmp + "16進整数値を入れてください";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16進long整数の範囲外チェック
        /// </summary>
        /// <param name="param">パラメータの入った文字列</param>
        /// <param name="ret_val">チェックOKのときlong型の値が返る</param>
        /// <param name="str_min">10進数最小閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">10進数最大閾値(最小閾値≦パラメータ≦最大閾値のときエラー) 判定しない時は""(空白)を指定</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHexInv(param, out ret_val, str_min, str_max, out dummy);
        }

        #endregion

        #region 文字列の型チェック(string型)
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  文字列の一致チェック
        /// </summary>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="param">パラメータ</param>
        /// <param name="str_limits">一致をチェックする文字列の配列(大文字小文字含めて完全一致)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidString(string param, string[] str_limits, out string err_msg)
        {
            long res = Common.AQUA_ERROR;

            err_msg = "";

            //nullチェック
            if (param == null)
            {
                err_msg = "文字列を入れてください";
                return Common.AQUA_ERROR;
            }

            if (str_limits != null)
            {
                foreach (string str_cmp in str_limits)
                {
                    if (param == str_cmp)
                    {
                        res = Common.AQUA_SUCCESS;
                        break;
                    }
                }

                if (res == Common.AQUA_ERROR)
                {
                    foreach (string str_cmp in str_limits)
                    {
                        err_msg += "\"" + str_cmp + "\" ";
                    }
                    err_msg += "のどれかを指定して下さい";
                }
            }
            else
            {
                err_msg = "比較用文字列のプログラムエラー(str_limits = null)";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  文字列の不一致チェック (設定ファイルマクロの STR NOT (,) に相当)
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="str_limits">不一致をチェックする文字列の配列(大文字小文字含めて完全一致でチェックNG)</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidStringInv(string param, string[] str_limits, out string err_msg)
        {
            long res = Common.AQUA_SUCCESS;

            err_msg = "";

            //nullチェック
            if (param == null)
            {
                err_msg = "文字列を入れてください";
                return Common.AQUA_ERROR;
            }

            if (str_limits != null)
            {
                foreach (string str_cmp in str_limits)
                {
                    if (param == str_cmp)
                    {
                        res = Common.AQUA_ERROR;
                        break;
                    }
                }

                if (res == Common.AQUA_ERROR)
                {
                    foreach (string str_cmp in str_limits)
                    {
                        err_msg += "\"" + str_cmp + "\" ";
                    }
                    err_msg += "以外の文字列を指定して下さい";
                }
            }
            else
            {
                res = Common.AQUA_ERROR;
                err_msg = "比較用文字列のプログラムエラー(str_limits = null)";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  文字列の長さチェック (設定ファイルマクロの STR LEN (,) に相当)
        /// </summary>
        /// <param name="param_name">パラメータの名前(設定ファイルマクロと表記を合わせる)</param>
        /// <param name="param">パラメータ</param>
        /// <param name="str_min">最小長さ(この値未満でエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="str_max">最大長さ(この値より大きいとエラー) 判定しない時は""(空白)を指定</param>
        /// <param name="err_msg">チェックNGのときエラーメッセージが返る</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidString(string param, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int len_min;
            int len_max;

            err_msg = "";

            //nullチェック
            if (param == null)
            {
                err_msg = str_min + "から" + str_max + "までの長さの文字列を入れてください";
                return Common.AQUA_ERROR;
            }

            //判定する最小値を取得
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out len_min) || len_min < 0)
                {
                    err_msg = "範囲チェックの最小値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                len_min = 0;
            }

            //判定する最大値を取得
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out len_max))
                {
                    err_msg = "範囲チェックの最大値のエラー";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                len_max = param.Length; //C#の文字列の長さに制限はないので必ずPASSするようにする
            }

            if (param.Length >= len_min && param.Length <= len_max)
            {
                res = Common.AQUA_SUCCESS;
            }

            if (res == Common.AQUA_ERROR) { err_msg = str_min + "から" + str_max + "までの長さの文字列を入れてください"; }

            return (res);
        }

        #endregion
    }

    /// <summary>
    /// 共通関数クラス
    /// </summary>
    public sealed class CommonFunc
    {
        //--- 共通関数 ------------------------------------------
        //全体で使えるような関数はここに入れてください
        //
        //ここで作った関数を使う場合は、関数名がXXX()の場合、
        //CommonFunc.XXX();
        //と、このクラス名.関数名 で使ってください。
        //

        //
        //static publicで宣言する
        //

        #region JoinWithDQ : 文字列配列をJoinする。但し、区切り文字が含まれている場合は要素を""で囲む
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///   文字列配列をJoinする。但し、区切り文字が含まれている場合は要素を""で囲む
        /// </summary>
        /// <param name="separator">区切り文字列 ( " を含む文字列は指定不可)</param>
        /// <param name="value">string型の配列</param>
        /// <returns>Joinした後の文字列</returns>
        /// 2010/10/19 E2N1 tanaka
        ///////////////////////////////////////////////////////////////////
        public static string JoinWithDQ(string separator, string[] value)
        {
            if (separator == null) { return ""; }
            if (value == null) { return null; }
            if (separator.IndexOf("\"") > -1) { return null; }

            //区切り文字が空文字の場合string.Joinと同じ
            if (separator == "")
            {
                return string.Join(separator, value);
            }

            //valueを変更してしまうのでコピー
            string[] copy_value = new string[value.Length];
            Array.Copy(value, copy_value, value.Length);

            for (int i = 0; i < copy_value.Length; i++)
            {
                //区切り文字がある場合は""で囲む
                if (copy_value[i].IndexOf(separator) > -1)
                {
                    copy_value[i] = "\"" + copy_value[i] + "\"";
                }
            }

            return string.Join(separator, copy_value);
        }
        #endregion

        #region SplitWithDQ : 文字列をSplitする。但し、区切り文字間全体を""で囲んだ場合はSplitしない
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  文字列をSplitする。但し、区切り文字間全体を""で囲んだ場合はSplitしない
        /// </summary>
        /// <param name="str_param">カンマでSplitする元の文字列</param>
        /// <param name="sep">区切り文字 ( " は指定不可)</param>
        /// <param name="options">返される配列で空の要素を省略する場合は System.StringSplitOptions.RemoveEmptyEntries。返される配列に空の要素も含める場合は System.StringSplitOptions.None。</param>
        /// <returns>Splitした後の配列</returns>
        /// 2010/03/03 E2N1 tanaka
        ///////////////////////////////////////////////////////////////////
        public static string[] SplitWithDQ(string param, char sep, System.StringSplitOptions options)
        {
            int first_DQ;
            int last_DQ;
            char rep = '\0';
            int i;
            string[] str_params;

            if (param == null || param == "")
            {
                return null;
            }

            //分割する文字に " が含まれていた場合はNG
            if (sep == '"') { return null; }

            //文中に " がない場合は通常通りsplit
            if (param.IndexOf('"') < 0)
            {
                return param.Split(new char[] { sep }, options);
            }

            //文中に使われていない文字を検索
            i = 0x1A;
            do
            {
                //見つからなかった文字をrepにする
                if (param.IndexOf((char)i) < 0)
                {
                    rep = (char)i;
                    break;
                }
                i++;
            } 
            while (i < 0x7F);

            if (rep == '\0')
            {
                return null;
            }

            // " で囲まれた部分の sep を rep に置き換える
            first_DQ = -1;
            last_DQ = -1;
            for (i = 0; i < param.Length; i++)
            {
                //先頭か、区切り文字の次の文字が "
                if (((i == 0 && param[i] == '"') || (i > 0 && param[i - 1] == sep && param[i] == '"')) && first_DQ == -1)
                {
                    first_DQ = i;
                }
                //末尾か、区切り文字の前の文字が "
                else if (((i == param.Length - 1 && param[i] == '"') || (i < param.Length - 1 && param[i] == '"' && param[i + 1] == sep)) && last_DQ == -1 && first_DQ != -1)
                {
                    last_DQ = i;
                }

                if (first_DQ >= 0 && last_DQ >= 0)
                {
                    string str_front = param.Substring(0, first_DQ);
                    string str_middle;

                    if (last_DQ - first_DQ - 1 > 0)
                    {
                        str_middle = param.Substring(first_DQ + 1, last_DQ - first_DQ - 1);
                    }
                    else
                    {
                        str_middle = "";
                    }
                    string str_back = param.Substring(last_DQ + 1);

                    first_DQ = -1;
                    last_DQ = -1;

                    // " を抜いて、 sep を rep に変換した形で上書きする
                    param = str_front + str_middle.Replace(sep, rep) + str_back;
                    i--;
                }
            }

            str_params = param.Split(new char[] { sep }, options);

            // rep を sep にもどす
            for (i = 0; i < str_params.Length; i++)
            {
                str_params[i] = str_params[i].Replace(rep, sep);
            }

            return str_params;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  文字列をSplitする。但し、""で囲まれた部分ではSplitしない
        /// </summary>
        /// <param name="str_param">カンマでSplitする元の文字列</param>
        /// <param name="sep">区切り文字 ( " は指定不可)</param>
        /// <returns>Splitした後の配列</returns>
        /// 2010/03/03 E2N1 tanaka
        ///////////////////////////////////////////////////////////////////
        public static string[] SplitWithDQ(string param, char sep)
        {
            return SplitWithDQ(param, sep, StringSplitOptions.None);
        }
        #endregion

        #region 1msec精度のｽﾘｰﾌﾟ
        //APIのｲﾝﾎﾟｰﾄ
        [DllImport("winmm.dll")]
        private static extern uint timeBeginPeriod(uint uPeriod);
        [DllImport("winmm.dll")]
        private static extern uint timeEndPeriod(uint uPeriod);
        [DllImport("winmm.dll")]
        private static extern void timeGetDevCaps(out TimeCaps timeCaps, int size);

        //ﾏﾙﾁﾒﾃﾞｨｱ分解能格納用構造体
        public struct TimeCaps
        {
            public uint wPeriodMin;
            public uint wPeriodMax;
        }
        /// <summary>
        /// ｼｽﾃﾑ最少分解能でのｽﾘｰﾌﾟ
        /// </summary>
        /// <param name="millisec">ｽﾚｯﾄﾞ待機時間</param>
        public static void Sleep(int millisec)
        {
            //最少分解能取得
            TimeCaps timeCaps;
            timeGetDevCaps(out timeCaps, Marshal.SizeOf(typeof(TimeCaps)));

            //最少分解能に設定
            timeBeginPeriod(timeCaps.wPeriodMin);

            //ｽﾘｰﾌﾟ
            System.Threading.Thread.Sleep(millisec);

            //分解能をもとに戻しておく (必ず入れる)
            timeEndPeriod((uint)timeCaps.wPeriodMin);
        }
        #endregion 1msec精度のｽﾘｰﾌﾟ

        #region valに対するref_valのdBrを計算する
        //----------------------------------------------------
        //  関数    ：TodBr
        ///<summary>  valに対するref_valのdBrを計算する 
        /// </summary>
        /// <param name="val">値</param>
        /// <param name="ref_val">基準値</param>
        //  引数    ：【double】val
        //          ：【double】ref_val
        //  戻値    ：【double】20 * log_10(val / ref_val)
        //  履歴    ： 2008/09/02 tanaka
        //----------------------------------------------------
        public static double TodBr(double val, double ref_val)
        {
            return (20 * Math.Log10(val / ref_val));
        }
        #endregion

        #region 結果の番号から結果グループを考慮して適切な結果構造体を取得する
        //----------------------------------------------------
        /// <summary>
        ///   結果の番号から結果グループを考慮して適切な結果構造体を取得する
        /// </summary>
        /// <param name="No">結果の番号</param>
        /// <param name="configTest">ConfigTest構造体</param>
        /// <param name="testResult">TestResult結果構造体</param>
        /// <returns>成功でCommon.AQUA_SUCCESS</returns>
        //----------------------------------------------------
        public static long GetTestResultByNumber(int No, ConfigTest configTest, out TestResult testResult)
        {
            //結果が5つあって、結果グループが3つ、{1,2} , {3,4}, 5 と設定されていた場合、
            //4番目の結果に対応する結果構造体は2番目になる
            long res = Common.AQUA_ERROR;
            testResult = new TestResult();

            int spec_num = -1;
            int count = 0;

            //結果グループから適切なスペックを取得する
            //各結果グループの結果数を足していってNoを超えたときの結果グループが
            //Noの結果が属している結果グループ
            for (int i = 0; i < configTest.resultNum.groupNum; i++)
            {
                count += configTest.resultNum.resultGroup[i];
                if (No < count)
                {
                    spec_num = i;
                    break;
                }
            }
            if (spec_num >= 0)
            {
                testResult = configTest.testResult[spec_num];
                res = Common.AQUA_SUCCESS;
            }

            return res;
        }

        #endregion

        #region 周波数からWiFiのCHに変換する
        //----------------------------------------------------
        //  関数    ：FreqToChannel
        ///<summary>  freq(Hz)に対するWLanのチャンネルを返す
        /// </summary>
        /// <param name="freq">周波数</param>
        //  引数    ：【double】freq
        //  戻値    ：【string】
        //  履歴    ： 2011/02/09 kida
        //----------------------------------------------------
        public static string FreqToWLanCh(double freq)
        {
            long ch;
            if (freq == 2412e6)
            {
                ch = 1;
            }
            else if (freq == 2417e6)
            {
                ch = 2;
            }
            else if (freq == 2422e6)
            {
                ch = 3;
            }
            else if (freq == 2427e6)
            {
                ch = 4;
            }
            else if (freq == 2432e6)
            {
                ch = 5;
            }
            else if (freq == 2437e6)
            {
                ch = 6;
            }
            else if (freq == 2442e6)
            {
                ch = 7;
            }
            else if (freq == 2447e6)
            {
                ch = 8;
            }
            else if (freq == 2452e6)
            {
                ch = 9;
            }
            else if (freq == 2457e6)
            {
                ch = 10;
            }
            else if (freq == 2462e6)
            {
                ch = 11;
            }
            else if (freq == 2467e6)
            {
                ch = 12;
            }
            else if (freq == 2472e6)
            {
                ch = 13;
            }
            else if (freq == 2484e6)
            {
                ch = 14;
            }
            else
            {
                ch = 0;
            }

            return ch.ToString();
        }
        #endregion

        #region 周波数からWiFiのCHに変換する(文字列版)
        //----------------------------------------------------
        //  関数    ：FreqToChannel
        ///<summary>  freq(Hz)に対するWLanのチャンネルを返す
        /// </summary>
        /// <param name="freq">周波数</param>
        //  引数    ：【double】freq
        //  戻値    ：【string】
        //  履歴    ： 2011/02/09 kida
        //----------------------------------------------------
        public static string FreqToWLanCh(string sfreq)
        {
            double freq;

            try
            {
                freq = Convert.ToDouble(sfreq);
            }
            catch (Exception)
            {
                freq = 0;
            }

            return FreqToWLanCh(freq);
        }
        #endregion

        #region 指定したアプリケーションを終了させる。(ファイル名全体を指定)
        //----------------------------------------------------
        //  関数    ：ExecStopApp
        /// <summary>  指定したアプリケーションを終了させる。(ファイル名全体を指定)
        /// </summary>
        /// <param name="app_name">対象のファイル名</param>
        /// <param name="wait">終了待ち時間(msec)</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool ExecStopApp(string app_name, int wait)
        {
            string[] s = app_name.Split('.');
            if (s[s.Length - 1].ToLower() == "exe") { app_name = app_name.Remove(app_name.Length - 4); }

            try
            {
                Process my_process = Process.GetCurrentProcess();
                Process[] app_proc = Process.GetProcessesByName(app_name);
                if (app_proc.Length >= 1)
                {
                    foreach (Process p in app_proc)      //一度普通に終わらせる。
                    {
                        if (p.Id != my_process.Id)
                        {
                            Debug.WriteLine(p.Id);
                            p.CloseMainWindow();
                            p.WaitForExit(wait);
                        }
                    }
                    app_proc = Process.GetProcessesByName(app_name);
                    foreach (Process p in app_proc)      //残っていたら強制終了。
                    {
                        if (p.Id != my_process.Id)
                        {
                            Debug.WriteLine(p.Id);
                            p.Kill();
                            p.WaitForExit(wait);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 指定した文字列で始まるアプリケーションをすべて終了させる。(ファイル名の先頭部分の文字列を指定)
        //----------------------------------------------------
        //  関数    ：ExecStopAllApp
        /// 指定した文字列で始まるアプリケーションをすべて終了させる。(ファイル名の先頭部分の文字列を指定)
        /// </summary>
        /// <param name="app_name">対象のファイル名(".exe"を含まない名前。15文字以下)</param>
        /// <param name="wait">終了待ち時間(msec)</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool ExecStopAllApp(string app_name, int wait)
        {
            try
            {
                Process my_process = Process.GetCurrentProcess();
                Process[] all_process = Process.GetProcesses();
                foreach (Process p in all_process)      //一度普通に終わらせる。
                {
                    if (p.ProcessName.StartsWith(app_name))
                    {
                        if (p.Id != my_process.Id)
                        {
                            Debug.WriteLine(p.Id);
                            p.CloseMainWindow();
                            p.WaitForExit(wait);
                        }
                    }
                }
                all_process = Process.GetProcesses();
                foreach (Process p in all_process)      //残っていたら強制終了。
                {
                    if (p.ProcessName.StartsWith(app_name))
                    {
                        if (p.Id != my_process.Id)
                        {
                            Debug.WriteLine(p.Id);
                            p.Kill();
                            p.WaitForExit(wait);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 文字列中に指定したパターンと一致する箇所を取得する
        //----------------------------------------------------
        //  関数    ：GetStringFromMessage
        /// 文字列の中に指定したパターンと一致する箇所を取得する
        /// </summary>
        /// <param name="pattern">正規表現</param>
        /// <param name="msg">検索する文字列</param>
        /// <param name="response">該当した文字列</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool GetStringsFromMessage(string pattern, string msg, out string hitstrings)
        {
            hitstrings = "";

            string code = "";

            if (!CommonFunc.GetBetweenStrings("<", ">", pattern, out code))
            {
                return false;
            }

            Regex reg = new Regex(@pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            Match m = reg.Match(msg);

            if (m.Success)
            {
                hitstrings = m.Groups[code].Value;
                m = m.NextMatch();
            }
            else
            {
                return false;
            }
            //複数個一致したらエラーとする
            if (m.Success)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 文字列中に指定した文字間の文字列を取得する
        //----------------------------------------------------
        //  関数    ：GetBetweenStrings
        /// 2つの文字列の間の文字列を返す
        /// </summary>
        /// <param name="str1">1つ目の文字</param>
        /// <param name="str2">2つ目の文字</param>
        /// <param name="str2">抽出された文字</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool GetBetweenStrings(string str1, string str2, string orgStr, out string hitstrings)
        {
            int orgLen = orgStr.Length; //原文の文字列の長さ        
            int str1Len = str1.Length; //str1の長さ                    
            int str1Num = orgStr.IndexOf(str1); //str1が原文のどの位置にあるか        
            hitstrings = ""; //返す文字列   

            //例外処理       
            try
            {
                hitstrings = orgStr.Remove(0, str1Num + str1Len); //原文の初めからstr1のある位置まで削除                
                int str2Num = hitstrings.IndexOf(str2); //str2がsのどの位置にあるか                
                hitstrings = hitstrings.Remove(str2Num); //sのstr2のある位置から最後まで削除        
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
