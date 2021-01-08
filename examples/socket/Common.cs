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
    //�ǂ�����ł��Q�Ƃł��鋤�ʐݒ�
    public static class CommonSetting
    {
        //�Ή����W���[���B�����ɏ��������O�ƃR���t�B�O���[�V�����t�@�C���ɋL�ڂ���Ă���
        //���W���[��������v���Ȃ��ƌx�����o��
        public static string[] TARGET_MODULE = new string[] { "Type1WP" };

        //�f�B���N�g���p�X (�p�X�ɂ͍Ō�́����܂�)            
        public static string PATH_EXE;              //exe�̏ꏊ
        public static string PATH_ROOT;             //���[�g�t�H���_
        public static string PATH_WAVEFORM;         //�E�F�u�t�H�[���̕ۑ���t�H���_
        public static string PATH_CABLELOSS;        //�P�[�u�����X�t�H���_
        public static string PATH_MODULESCRIPT;     //���W���[���X�N���v�g�t�H���_

        //�t�@�C���p�X
        public static string PATH_FILE_PATH;            // �p�X�ݒ�t�@�C��
        public static string PATH_FILE_SYSTEM;          // �V�X�e���t�@�C��
        public static string PATH_FILE_INSTRUMENT;      // �����ݒ�t�@�C��
        public static string PATH_FILE_ENVIRONMENT;     // ���t�@�C��
        public static string PATH_FILE_GAMEN;           // ��ʐݒ�t�@�C��
        public static string PATH_FILE_MASK;            // �}�X�N�t�@�C��
        public static string PATH_FILE_ADDRESS;         // ���[�J���A�h���X�t�@�C��
        public static string PATH_FILE_SERIAL;          // �V���A���ԍ��t�@�C��
        public static string PATH_FILE_UNIT;            // �P�ʃt�@�C��
        public static string PATH_FILE_AUTORANGE;       // AutoRange�t�@�C��
        public static string PATH_FILE_LAUNCHER;        // Launcher�t�@�C��

        public static string LOT_ID;                //���b�gID
        public static string LINE_NAME;             //���C����
        public static string HEAD_NAME;             //�w�b�h��

    }

    //pingpong�p
    public static class PingPong
    {
        //public static int N4010A_VISA_FLAG = 0; // LockStateControl = 1 / normal = 0
        public static int N4010A_VISA_FLAG = 0; //pingpong lock = 2 / unlock = 1 / pingpon nashi = 0
        public static string N4010A_VISA_UDP = "";  // 
        public static string N4010A_VISA_UDP_PORT = ""; // 
        public static string N4010A_LSC_NAME = "";
    }

    //Factory�p
    public static class CommonFactory
    {
        public static bool FactoryEnable = false;       //2012/03/14�ǉ� ON�ɂ���ƁA�����グ���`�F�b�N������
        public static string FactoryName = "";
        public static string SystemID = "";
        public static string ServerIP = "";
        public static string ServerPort = "";
        public static string TimeOut = "";
        public static string BusyWait = "";
        public static string NumberFolder = "";         //2012/03/14�ǉ�
        public static string NumberHead = "";           //��MAC�̐擪�A�h���X
    }

    //DIO�p 
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
    //���ʒ萔�N���X
    //���̃N���X���Ő錾���ꂽ�萔��namespace AQUA���̑S�N���X
    //�Ŏg�p�ł���B
    // 2008/08/27 tanaka
    public static class Common
    {
        //--- ���ʒ萔 ---------------------------------------------
        //�S�̂Ŏg����悤�Ȓ萔�͂����ɓ���Ă��������B
        //�X�̈Č��ł�ނ𓾂��g�p���鋤�ʒ萔�͕ʂ�static class������ĊǗ����ĉ�����
        //�����𒼑ł�������A�Ȃ�ׂ������ɂ���萔���g���Ă�������
        //
        //�����ō�����萔���g���ꍇ�́A�萔����XXX�̏ꍇ�A
        //Common.XXX;
        //�ƁA���̃N���X��.�萔�� �Ŏg���Ă��������B
        //
        //public �Ő錾����

        //���O
        //Properties\AssemblyInfo.cs ���� [assembly: AssemblyProduct("****")] �ɋL�q����
        //�v���O����������� Application.ProductName ���g�p����
        //public const string ApplicationName = "Aqua II (moyashi)";

        //�o�[�W����
        //Properties\AssemblyInfo.cs ���� [assembly: AssemblyVersion("*.*.*.*")] �ɋL�q����
        //�ύX�����́A�ύX����.txt�ɋL�q����
        //�v���O����������� Common.ApplicationVersion ���g�p����
        //Application.ProductVersion �̌�͈���ȂǓ���Ɏg��(�� " with Tuner", ".��" �Ȃ�)
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

        //�߂�l
        public const int AQUA_INIT = 0;
        public const int AQUA_SUCCESS = 1;
        public const int AQUA_EXIT = 2;
        public const int AQUA_PASS = 1;
        public const int AQUA_FAIL = -1;
        public const int AQUA_ERROR = -2;
        public const int AQUA_ABORT = -3;
        public const int AQUA_ANOTHER = -4;

        //�P�ʌn
        public const double NANO = 0.000000001;
        public const double MICRO = 0.000001;
        public const double MIRI = 0.001;
        public const int KIRO = 1000;
        public const int MEGA = 1000000;
        public const long GIGA = 1000000000;

        public const int KHZ = 1000;
        public const int MHZ = 1000000;
        public const long GHZ = 1000000000;

        //���O�o��
        public const uint LogCategory_Comment = 0x1;        // Log���ރR�[�h �R�����g�o��
        public const uint LogCategory_Error = 0x2;          // Log���ރR�[�h �G���[
        public const uint LogCategory_Target = 0x4;         // Log���ރR�[�h ���W���[������
        public const uint LogCategory_Instrument = 0x8;     // Log���ރR�[�h ����퐧��
        public const uint LogCategory_GPIB = 0x8000000;     // Log���ރR�[�h I/F GPIB
        public const uint LogCategory_LAN = 0x10000000;     // Log���ރR�[�h I/F LAN
        public const uint LogCategory_UDP = 0x20000000;     // Log���ރR�[�h I/F UDP
        public const uint LogCategory_VISA = 0x40000000;    // Log���ރR�[�h I/F VISA
        public const uint LogCategory_COM = 0x80000000;     // Log���ރR�[�h I/F COM
        public const int LogGroup_Disable = -1;         // Log�O���[�v�R�[�h �o�͋֎~
        public const int LogGroup_Default = 0;          // Log�O���[�v�R�[�h �f�t�H���g

        //--(�萔�@�����܂�)-------------------------------------

        //--- ���ʕϐ� ------------------------------------------
		public static string DUT_Macaddress = "";                  //DB�p�ɕێ�MAC
        public static string DUT_BDaddress = "";                   //DB�p�ɕێ�BD
        public static string DUT_2DCODE = "";                      //DB�p�ɕێ�2DCode
        public static bool DUT_2DCODE_READ_FLG = false;            //DB�p�ɕێ�2D��ǂ񂾂��ǂ����̃t���O(one time)
        public static string DUT_CERTIFICATE_PATH = "";            //DB�p PRASS����̏ؖ����t�@�C���̃p�X���Z�b�g���܂�
        public static string PRASS_MSG = "";                       //DB�p PRASS����̃G���[���b�Z�[�W���Z�b�g���܂�
        public static string PRASS_CODE = "";                      //DB�p PRASS����̃G���[�R�[�h���Z�b�g���܂�
        public static string PRASS_RETESTCOUNT = "";               //DB�p PRASS����̍đ���J�E���g���Z�b�g���܂�
        public static string DUT_SSID = "";
        public static string DUT_KEY = "";

		//HTTP PRASS�n ����
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

        public static bool ExitThreadFig = false;                   //http�ʐM�X���b�h�I���t���O
        public static long processflag = 0; //0: BT�V�[�P���X����Ȃ� 1: BT�V�[�P���X����J�n 2: BT�V�[�P���X���蒆
        public static bool measTimeLogFlag = false;
        public static bool timeoutflag = false;
        public static bool Imp_update_skip = false; //Imp�pOTP�������݃t���O
        public static bool one_time_run_flg = true; //Imp�p����̂ݎ��s�t���O
        public static bool ayla_serial_write_skip = false; //Ayla�pserial�������݃t���O
        public static string ayla_serial = "";//Ayla�pserial,Skip���ۑ��p
        public static bool ayla_relabel = false; //Ayla�p

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
        //�l�b�g���[�N��IP�ƃX�e�[�^�X���擾����
        public static List<Network_struct> GetNetwork()
        {
            List<Network_struct> nstruct = new List<Network_struct>();
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nis)
            {
                Network_struct mnet = new Network_struct();
                IPInterfaceProperties ip_prop = adapter.GetIPProperties();

                // ���j�L���X�g IP �A�h���X�̎擾
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
        //---(�֐��@�����܂Łj------------------------------------
    }

    /// <summary>
    ///  �G���[�`�F�b�N�N���X
    /// </summary>
    public sealed class Validation
    {
        public enum SEL_INT_HEX
        {
            INT = 0,
            HEX = 1
        }

        #region �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̌^�͈̓`�F�b�N
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  int�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ� 
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  int�^(16�i�� �I����): �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ�
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <param name="sel">10�i�̂Ƃ�: Validation.SEL_INT_HEX.INT, 16�i("0x**"�̌`): Validation.SEL_INT_HEX.HEX ��I��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out int ret_val, string str_min, string str_max, string param_name, out string err_msg, Validation.SEL_INT_HEX sel)
        {
            long res = Common.AQUA_ERROR;

            ret_val = 9999;
            err_msg = "";

            //���ʂ̐����̏ꍇ
            if (sel == SEL_INT_HEX.INT)
            {
                res = isValidInt(param, out ret_val, str_min, str_max, out err_msg);
            }
            //16�i���̏ꍇ
            else if (sel == SEL_INT_HEX.HEX)
            {
                res = isValidHex(param, out ret_val, str_min, str_max, out err_msg);
            }
            else
            {
                err_msg = "�v���O�����G���[ sel�ɗ^����������Ⴂ�܂�";
                res = Common.AQUA_ERROR;
            }

            if (res != Common.AQUA_SUCCESS)
            {
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ�
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�^(16�i�� �I����): �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ�
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <param name="sel">10�i�̂Ƃ�: Validation.SEL_INT_HEX.INT, 16�i("0x**"�̌`): Validation.SEL_INT_HEX.HEX ��I��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidParameter(string param, out long ret_val, string str_min, string str_max, string param_name, out string err_msg, Validation.SEL_INT_HEX sel)
        {
            long res = Common.AQUA_ERROR;

            ret_val = 9999;
            err_msg = "";

            //���ʂ̐����̏ꍇ
            if (sel == SEL_INT_HEX.INT)
            {
                res = isValidLong(param, out ret_val, str_min, str_max, out err_msg);
            }
            //16�i���̏ꍇ
            else if (sel == SEL_INT_HEX.HEX)
            {
                res = isValidHex(param, out ret_val, str_min, str_max, out err_msg);
            }
            else
            {
                err_msg = "�v���O�����G���[ sel�ɗ^����������Ⴂ�܂�";
                res = Common.AQUA_ERROR;
            }

            if (res != Common.AQUA_SUCCESS)
            {
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  double�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ� (����)
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�double�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  string�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ� (�����`�F�b�N)
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�param�Ɠ����̕����񂪕Ԃ�</param>
        /// <param name="str_min">�ŏ�����(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő咷��(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  string�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ� (��v�`�F�b�N)
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�param�Ɠ����̕����񂪕Ԃ�</param>
        /// <param name="str_cmps">��v���r���镶����̔z�� (��F new string[] {"ON, "OFF"} �j</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  bool�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ�
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <param name="str_true">True �Ɣ��f���镶����</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  bool�^ : �ݒ�t�@�C������ǂݍ��񂾃p�����[�^�̃`�F�b�N/�ϊ�
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="int_false">False �Ɣ��f���鐔�l</param>
        /// <param name="int_true">True �Ɣ��f���鐔�l</param>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
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
                //�G���[���b�Z�[�W�Ƀp�����[�^����ǉ�
                err_msg = "�p�����[�^ " + param_name + " = \"" + param + "\" : " + err_msg;
            }

            return res;
        }

        #endregion

        #region �^�U�̐��l�`�F�b�N(bool�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̕�����`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <param name="str_true">True �Ɣ��f���镶����</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, string str_false, string str_true, out string err_msg)
        {
            long res = Common.AQUA_ERROR;

            err_msg = "";
            ret_val = false;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            res = Common.AQUA_SUCCESS;
            if (param == str_true) { ret_val = true; }
            else if (param == str_false) { ret_val = false; }
            else
            {
                err_msg = str_true + " �܂��� " + str_false + "���w�肵�Ă�������";
                res = Common.AQUA_ERROR;
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̕�����`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <param name="str_true">True �Ɣ��f���镶����</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, string str_false, string str_true)
        {
            string dummy;
            return isValidBool(param, out ret_val, str_false, str_true, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̕�����`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <param name="str_true">True �Ɣ��f���镶����</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, string str_false, string str_true, out string err_msg)
        {
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, str_false, str_true, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̕�����`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <param name="str_true">True �Ɣ��f���镶����</param>
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
        ///  �^�U�̐��l�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="int_false">False �Ɣ��f���鐔�l</param>
        /// <param name="int_true">True �Ɣ��f���鐔�l</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, int int_false, int int_true, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_param;
            err_msg = "";
            ret_val = false;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out int_param))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                err_msg = int_true + " �܂��� " + int_false + "���w�肵�Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̐��l�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�bool�^�̒l���Ԃ�</param>
        /// <param name="int_false">False �Ɣ��f���鐔�l</param>
        /// <param name="int_true">True �Ɣ��f���鐔�l</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, out bool ret_val, int int_false, int int_true)
        {
            string dummy;
            return isValidBool(param, out ret_val, int_false, int_true, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̐��l�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="int_false">False �Ɣ��f���鐔�l</param>
        /// <param name="int_true">True �Ɣ��f���鐔�l</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, int int_false, int int_true, out string err_msg)
        {
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, int_false, int_true, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �^�U�̐��l�`�F�b�N
        /// </summary>
        /// <param name="int_false">False �Ɣ��f���鐔�l</param>
        /// <param name="int_true">True �Ɣ��f���鐔�l</param>
        /// <param name="str_false">False �Ɣ��f���镶����</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidBool(string param, int int_false, int int_true)
        {
            string str_dummy;
            bool bool_dummy;
            return isValidBool(param, out bool_dummy, int_false, int_true, out str_dummy);
        }

        #endregion

        #region �����̌^�`�F�b�N(int�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "")
                {
                    tmp += "��";
                }
                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidInt(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidInt(string param, string str_min, string str_max, out string err_msg)
        {
            int int_dummy;
            return isValidInt(param, out int_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            if (int.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidIntInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidIntInv(string param, string str_min, string str_max, out string err_msg)
        {
            int int_dummy;

            return isValidIntInv(param, out int_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region �����̌^�`�F�b�N(uint�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�uint�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, out uint ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            uint uint_min;
            uint uint_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!uint.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out uint_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_min = uint.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!uint.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out uint_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_max = uint.MaxValue;
            }

            if (uint.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "")
                {
                    tmp += "��";
                }
                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�uint�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, out uint ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUint(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUint(string param, string str_min, string str_max, out string err_msg)
        {
            uint uint_dummy;
            return isValidUint(param, out uint_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�uint�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, out uint ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            uint uint_min;
            uint uint_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!uint.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out uint_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_min = uint.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!uint.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out uint_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                uint_max = uint.MaxValue;
            }

            if (uint.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�uint�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, out uint ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUintInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUintInv(string param, string str_min, string str_max, out string err_msg)
        {
            uint uint_dummy;

            return isValidUintInv(param, out uint_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region �����̌^�`�F�b�N(short�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�short�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, out short ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            short short_min;
            short short_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!short.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out short_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_min = short.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!short.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out short_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_max = short.MaxValue;
            }

            if (short.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "")
                {
                    tmp += "��";
                }
                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�short�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, out short ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidShort(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShort(string param, string str_min, string str_max, out string err_msg)
        {
            short short_dummy;
            return isValidShort(param, out short_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�short�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, out short ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            short short_min;
            short short_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!short.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out short_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_min = short.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!short.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out short_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                short_max = short.MaxValue;
            }

            if (short.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�short�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, out short ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidShortInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidShortInv(string param, string str_min, string str_max, out string err_msg)
        {
            short short_dummy;

            return isValidShortInv(param, out short_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region �����̌^�`�F�b�N(ushort�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�ushort�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, out ushort ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ushort ushort_min;
            ushort ushort_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!ushort.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out ushort_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_min = ushort.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!ushort.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out ushort_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_max = ushort.MaxValue;
            }

            if (ushort.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "")
                {
                    tmp += "��";
                }
                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�ushort�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, out ushort ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUshort(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshort(string param, string str_min, string str_max, out string err_msg)
        {
            ushort ushort_dummy;
            return isValidUshort(param, out ushort_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�ushort�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, out ushort ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            ushort ushort_min;
            ushort ushort_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!ushort.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out ushort_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_min = ushort.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!ushort.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out ushort_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                ushort_max = ushort.MaxValue;
            }

            if (ushort.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�ushort�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, out ushort ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidUshortInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidUshortInv(string param, string str_min, string str_max, out string err_msg)
        {
            ushort ushort_dummy;

            return isValidUshortInv(param, out ushort_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region �����̌^�`�F�b�N(long�^)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            if (long.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "") 
                { 
                    tmp += "��"; 
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  long�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, string str_min, string str_max, out string err_msg)
        {
            long lng_dummy;
            return isValidLong(param, out lng_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLong(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidLong(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// long�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            if (long.TryParse(param, System.Globalization.NumberStyles.Integer, null, out ret_val))
            {
                // System.Globalization.NumberStyles.Integer = �O��̋�,�O�̕����݂̂�����
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidLongInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  long�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  long�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidLongInv(string param, string str_min, string str_max, out string err_msg)
        {
            long lng_dummy;
            return isValidLongInv(param, out lng_dummy, str_min, str_max, out err_msg);
        }
        #endregion

        #region �����̌^�`�F�b�N(double�^)
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�double�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, out double ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            double dbl_min;
            double dbl_max;

            err_msg = "";
            ret_val = 9999.9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "���l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!double.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out dbl_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_min = double.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!double.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out dbl_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_max = double.MaxValue;
            }

            //������񐔒l("NaN")��\�킷�����łȂ����`�F�b�N(������TryParse��ʂ��Ă��܂�)
            //���l��.�ȊO���܂܂�鏑���łȂ����`�F�b�N
            if (param != System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NaNSymbol)
            {
                if (double.TryParse(param, System.Globalization.NumberStyles.Float, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.Float = �O��̋󔒁A�O�̕����A�����_�A�w���\�L�̂݋���
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "") 
                { 
                    tmp += "��"; 
                }

                err_msg = tmp + "���l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�double�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, out double ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidDouble(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDouble(string param, string str_min, string str_max, out string err_msg)
        {
            double dbl_dummy;
            return isValidDouble(param, out dbl_dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�double�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, out double ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            double dbl_min;
            double dbl_max;

            err_msg = "";
            ret_val = 9999.9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "���l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!double.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out dbl_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_min = double.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!double.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out dbl_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                dbl_max = double.MaxValue;
            }

            //������񐔒l("NaN")��\�킷�����łȂ����`�F�b�N(������TryParse��ʂ��Ă��܂�)
            //���l��.�ȊO���܂܂�鏑���łȂ����`�F�b�N
            if (param != System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol &&
                param != System.Globalization.NumberFormatInfo.CurrentInfo.NaNSymbol)
            {
                if (double.TryParse(param, System.Globalization.NumberStyles.Float, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.Float = �O��̋󔒁A�O�̕����A�����_�A�w���\�L�̂݋���
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "���l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�double�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, out double ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidDoubleInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  �����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidDoubleInv(string param, string str_min, string str_max, out string err_msg)
        {
            double dbl_dummy;
            return isValidDoubleInv(param, out dbl_dummy, str_min, str_max, out err_msg);
        }

        #endregion

        #region 16�i���̌^�`�F�b�N("0x**"�̌`)

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  16�iint�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "0x�Ŏn�܂�16�i�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            //"0x"�ł͂��܂��Ė�����΃G���[
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"�������������̂𐔒l�ɒ���
                if (int.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-f�����B"0x"�͕s���B
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "") 
                { 
                    tmp += "��"; 
                }

                err_msg = tmp + "0x�Ŏn�܂�16�i�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�iint�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHex(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�i�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
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
        ///  16�i�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, string str_min, string str_max, out string err_msg)
        {
            long dummy;
            return isValidHex(param, out dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  16�ilong�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "0x�Ŏn�܂�16�i�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            //"0x"�ł͂��܂��Ė�����΃G���[
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"�������������̂𐔒l�ɒ���
                if (long.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-f�����B"0x"�͕s���B
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
                    tmp += str_min + "�ȏ�";
                }
                if (str_max != "")
                {
                    tmp += str_max + "�ȉ�";
                }
                if (tmp != "") 
                {
                    tmp += "��";
                }

                err_msg = tmp + "0x�Ŏn�܂�16�i�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�ilong�����͈̔̓`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ��l(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�l(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHex(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHex(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�iint�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out int ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int int_min;
            int int_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "0x�Ŏn�܂�16�i�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out int_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_min = int.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out int_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                int_max = int.MaxValue;
            }

            //"0x"�ł͂��܂��Ė�����΃G���[
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"�������������̂𐔒l�ɒ���
                if (int.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-f�����B"0x"�͕s���B
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "16�i�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�iint�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�int�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out int ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHexInv(param, out ret_val, str_min, str_max, out dummy);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�i�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">10�i���ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
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
        /// 16�iint�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="str_min">�ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, string str_min, string str_max, out string err_msg)
        {
            int dummy;
            return isValidHexInv(param, out dummy, str_min, str_max, out err_msg);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�ilong�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out long ret_val, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            long lng_min;
            long lng_max;

            err_msg = "";
            ret_val = 9999;

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "0x�Ŏn�܂�16�i�����l�����Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!long.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out lng_min))
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_min = long.MinValue;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!long.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out lng_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                lng_max = long.MaxValue;
            }

            //"0x"�ł͂��܂��Ė�����΃G���[
            if (param.Trim().StartsWith("0x"))
            {
                //"0x"�������������̂𐔒l�ɒ���
                if (long.TryParse(param.Trim().Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out ret_val))
                {
                    //System.Globalization.NumberStyles.AllowHexSpecifier = 0-9,A-F,a-f�����B"0x"�͕s���B
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
                    tmp += str_min + "�����A�܂���" + str_max + "���傫��";
                }
                else if (str_min != "")
                {
                    tmp += str_min + "������";
                }
                else if (str_max != "")
                {
                    tmp += str_max + "���傫��";
                }

                err_msg = tmp + "16�i�����l�����Ă�������";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// 16�ilong�����͈̔͊O�`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^�̓�����������</param>
        /// <param name="ret_val">�`�F�b�NOK�̂Ƃ�long�^�̒l���Ԃ�</param>
        /// <param name="str_min">10�i���ŏ�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">10�i���ő�臒l(�ŏ�臒l���p�����[�^���ő�臒l�̂Ƃ��G���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidHexInv(string param, out long ret_val, string str_min, string str_max)
        {
            string dummy;
            return isValidHexInv(param, out ret_val, str_min, str_max, out dummy);
        }

        #endregion

        #region ������̌^�`�F�b�N(string�^)
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  ������̈�v�`�F�b�N
        /// </summary>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="str_limits">��v���`�F�b�N���镶����̔z��(�啶���������܂߂Ċ��S��v)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidString(string param, string[] str_limits, out string err_msg)
        {
            long res = Common.AQUA_ERROR;

            err_msg = "";

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "����������Ă�������";
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
                    err_msg += "�̂ǂꂩ���w�肵�ĉ�����";
                }
            }
            else
            {
                err_msg = "��r�p������̃v���O�����G���[(str_limits = null)";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  ������̕s��v�`�F�b�N (�ݒ�t�@�C���}�N���� STR NOT (,) �ɑ���)
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="str_limits">�s��v���`�F�b�N���镶����̔z��(�啶���������܂߂Ċ��S��v�Ń`�F�b�NNG)</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidStringInv(string param, string[] str_limits, out string err_msg)
        {
            long res = Common.AQUA_SUCCESS;

            err_msg = "";

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = "����������Ă�������";
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
                    err_msg += "�ȊO�̕�������w�肵�ĉ�����";
                }
            }
            else
            {
                res = Common.AQUA_ERROR;
                err_msg = "��r�p������̃v���O�����G���[(str_limits = null)";
            }

            return (res);
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  ������̒����`�F�b�N (�ݒ�t�@�C���}�N���� STR LEN (,) �ɑ���)
        /// </summary>
        /// <param name="param_name">�p�����[�^�̖��O(�ݒ�t�@�C���}�N���ƕ\�L�����킹��)</param>
        /// <param name="param">�p�����[�^</param>
        /// <param name="str_min">�ŏ�����(���̒l�����ŃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="str_max">�ő咷��(���̒l���傫���ƃG���[) ���肵�Ȃ�����""(��)���w��</param>
        /// <param name="err_msg">�`�F�b�NNG�̂Ƃ��G���[���b�Z�[�W���Ԃ�</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////
        public static long isValidString(string param, string str_min, string str_max, out string err_msg)
        {
            long res = Common.AQUA_ERROR;
            int len_min;
            int len_max;

            err_msg = "";

            //null�`�F�b�N
            if (param == null)
            {
                err_msg = str_min + "����" + str_max + "�܂ł̒����̕���������Ă�������";
                return Common.AQUA_ERROR;
            }

            //���肷��ŏ��l���擾
            if (str_min != "")
            {
                if (!int.TryParse(str_min, System.Globalization.NumberStyles.Any, null, out len_min) || len_min < 0)
                {
                    err_msg = "�͈̓`�F�b�N�̍ŏ��l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                len_min = 0;
            }

            //���肷��ő�l���擾
            if (str_max != "")
            {
                if (!int.TryParse(str_max, System.Globalization.NumberStyles.Any, null, out len_max))
                {
                    err_msg = "�͈̓`�F�b�N�̍ő�l�̃G���[";
                    return Common.AQUA_ERROR;
                }
            }
            else
            {
                len_max = param.Length; //C#�̕�����̒����ɐ����͂Ȃ��̂ŕK��PASS����悤�ɂ���
            }

            if (param.Length >= len_min && param.Length <= len_max)
            {
                res = Common.AQUA_SUCCESS;
            }

            if (res == Common.AQUA_ERROR) { err_msg = str_min + "����" + str_max + "�܂ł̒����̕���������Ă�������"; }

            return (res);
        }

        #endregion
    }

    /// <summary>
    /// ���ʊ֐��N���X
    /// </summary>
    public sealed class CommonFunc
    {
        //--- ���ʊ֐� ------------------------------------------
        //�S�̂Ŏg����悤�Ȋ֐��͂����ɓ���Ă�������
        //
        //�����ō�����֐����g���ꍇ�́A�֐�����XXX()�̏ꍇ�A
        //CommonFunc.XXX();
        //�ƁA���̃N���X��.�֐��� �Ŏg���Ă��������B
        //

        //
        //static public�Ő錾����
        //

        #region JoinWithDQ : ������z���Join����B�A���A��؂蕶�����܂܂�Ă���ꍇ�͗v�f��""�ň͂�
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///   ������z���Join����B�A���A��؂蕶�����܂܂�Ă���ꍇ�͗v�f��""�ň͂�
        /// </summary>
        /// <param name="separator">��؂蕶���� ( " ���܂ޕ�����͎w��s��)</param>
        /// <param name="value">string�^�̔z��</param>
        /// <returns>Join������̕�����</returns>
        /// 2010/10/19 E2N1 tanaka
        ///////////////////////////////////////////////////////////////////
        public static string JoinWithDQ(string separator, string[] value)
        {
            if (separator == null) { return ""; }
            if (value == null) { return null; }
            if (separator.IndexOf("\"") > -1) { return null; }

            //��؂蕶�����󕶎��̏ꍇstring.Join�Ɠ���
            if (separator == "")
            {
                return string.Join(separator, value);
            }

            //value��ύX���Ă��܂��̂ŃR�s�[
            string[] copy_value = new string[value.Length];
            Array.Copy(value, copy_value, value.Length);

            for (int i = 0; i < copy_value.Length; i++)
            {
                //��؂蕶��������ꍇ��""�ň͂�
                if (copy_value[i].IndexOf(separator) > -1)
                {
                    copy_value[i] = "\"" + copy_value[i] + "\"";
                }
            }

            return string.Join(separator, copy_value);
        }
        #endregion

        #region SplitWithDQ : �������Split����B�A���A��؂蕶���ԑS�̂�""�ň͂񂾏ꍇ��Split���Ȃ�
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �������Split����B�A���A��؂蕶���ԑS�̂�""�ň͂񂾏ꍇ��Split���Ȃ�
        /// </summary>
        /// <param name="str_param">�J���}��Split���錳�̕�����</param>
        /// <param name="sep">��؂蕶�� ( " �͎w��s��)</param>
        /// <param name="options">�Ԃ����z��ŋ�̗v�f���ȗ�����ꍇ�� System.StringSplitOptions.RemoveEmptyEntries�B�Ԃ����z��ɋ�̗v�f���܂߂�ꍇ�� System.StringSplitOptions.None�B</param>
        /// <returns>Split������̔z��</returns>
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

            //�������镶���� " ���܂܂�Ă����ꍇ��NG
            if (sep == '"') { return null; }

            //������ " ���Ȃ��ꍇ�͒ʏ�ʂ�split
            if (param.IndexOf('"') < 0)
            {
                return param.Split(new char[] { sep }, options);
            }

            //�����Ɏg���Ă��Ȃ�����������
            i = 0x1A;
            do
            {
                //������Ȃ�����������rep�ɂ���
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

            // " �ň͂܂ꂽ������ sep �� rep �ɒu��������
            first_DQ = -1;
            last_DQ = -1;
            for (i = 0; i < param.Length; i++)
            {
                //�擪���A��؂蕶���̎��̕����� "
                if (((i == 0 && param[i] == '"') || (i > 0 && param[i - 1] == sep && param[i] == '"')) && first_DQ == -1)
                {
                    first_DQ = i;
                }
                //�������A��؂蕶���̑O�̕����� "
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

                    // " �𔲂��āA sep �� rep �ɕϊ������`�ŏ㏑������
                    param = str_front + str_middle.Replace(sep, rep) + str_back;
                    i--;
                }
            }

            str_params = param.Split(new char[] { sep }, options);

            // rep �� sep �ɂ��ǂ�
            for (i = 0; i < str_params.Length; i++)
            {
                str_params[i] = str_params[i].Replace(rep, sep);
            }

            return str_params;
        }

        ///////////////////////////////////////////////////////////////////
        /// <summary>
        ///  �������Split����B�A���A""�ň͂܂ꂽ�����ł�Split���Ȃ�
        /// </summary>
        /// <param name="str_param">�J���}��Split���錳�̕�����</param>
        /// <param name="sep">��؂蕶�� ( " �͎w��s��)</param>
        /// <returns>Split������̔z��</returns>
        /// 2010/03/03 E2N1 tanaka
        ///////////////////////////////////////////////////////////////////
        public static string[] SplitWithDQ(string param, char sep)
        {
            return SplitWithDQ(param, sep, StringSplitOptions.None);
        }
        #endregion

        #region 1msec���x�̽ذ��
        //API�̲��߰�
        [DllImport("winmm.dll")]
        private static extern uint timeBeginPeriod(uint uPeriod);
        [DllImport("winmm.dll")]
        private static extern uint timeEndPeriod(uint uPeriod);
        [DllImport("winmm.dll")]
        private static extern void timeGetDevCaps(out TimeCaps timeCaps, int size);

        //�����ި�����\�i�[�p�\����
        public struct TimeCaps
        {
            public uint wPeriodMin;
            public uint wPeriodMax;
        }
        /// <summary>
        /// ���эŏ�����\�ł̽ذ��
        /// </summary>
        /// <param name="millisec">�گ�ޑҋ@����</param>
        public static void Sleep(int millisec)
        {
            //�ŏ�����\�擾
            TimeCaps timeCaps;
            timeGetDevCaps(out timeCaps, Marshal.SizeOf(typeof(TimeCaps)));

            //�ŏ�����\�ɐݒ�
            timeBeginPeriod(timeCaps.wPeriodMin);

            //�ذ��
            System.Threading.Thread.Sleep(millisec);

            //����\�����Ƃɖ߂��Ă��� (�K�������)
            timeEndPeriod((uint)timeCaps.wPeriodMin);
        }
        #endregion 1msec���x�̽ذ��

        #region val�ɑ΂���ref_val��dBr���v�Z����
        //----------------------------------------------------
        //  �֐�    �FTodBr
        ///<summary>  val�ɑ΂���ref_val��dBr���v�Z���� 
        /// </summary>
        /// <param name="val">�l</param>
        /// <param name="ref_val">��l</param>
        //  ����    �F�ydouble�zval
        //          �F�ydouble�zref_val
        //  �ߒl    �F�ydouble�z20 * log_10(val / ref_val)
        //  ����    �F 2008/09/02 tanaka
        //----------------------------------------------------
        public static double TodBr(double val, double ref_val)
        {
            return (20 * Math.Log10(val / ref_val));
        }
        #endregion

        #region ���ʂ̔ԍ����猋�ʃO���[�v���l�����ēK�؂Ȍ��ʍ\���̂��擾����
        //----------------------------------------------------
        /// <summary>
        ///   ���ʂ̔ԍ����猋�ʃO���[�v���l�����ēK�؂Ȍ��ʍ\���̂��擾����
        /// </summary>
        /// <param name="No">���ʂ̔ԍ�</param>
        /// <param name="configTest">ConfigTest�\����</param>
        /// <param name="testResult">TestResult���ʍ\����</param>
        /// <returns>������Common.AQUA_SUCCESS</returns>
        //----------------------------------------------------
        public static long GetTestResultByNumber(int No, ConfigTest configTest, out TestResult testResult)
        {
            //���ʂ�5�����āA���ʃO���[�v��3�A{1,2} , {3,4}, 5 �Ɛݒ肳��Ă����ꍇ�A
            //4�Ԗڂ̌��ʂɑΉ����錋�ʍ\���̂�2�ԖڂɂȂ�
            long res = Common.AQUA_ERROR;
            testResult = new TestResult();

            int spec_num = -1;
            int count = 0;

            //���ʃO���[�v����K�؂ȃX�y�b�N���擾����
            //�e���ʃO���[�v�̌��ʐ��𑫂��Ă�����No�𒴂����Ƃ��̌��ʃO���[�v��
            //No�̌��ʂ������Ă��錋�ʃO���[�v
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

        #region ���g������WiFi��CH�ɕϊ�����
        //----------------------------------------------------
        //  �֐�    �FFreqToChannel
        ///<summary>  freq(Hz)�ɑ΂���WLan�̃`�����l����Ԃ�
        /// </summary>
        /// <param name="freq">���g��</param>
        //  ����    �F�ydouble�zfreq
        //  �ߒl    �F�ystring�z
        //  ����    �F 2011/02/09 kida
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

        #region ���g������WiFi��CH�ɕϊ�����(�������)
        //----------------------------------------------------
        //  �֐�    �FFreqToChannel
        ///<summary>  freq(Hz)�ɑ΂���WLan�̃`�����l����Ԃ�
        /// </summary>
        /// <param name="freq">���g��</param>
        //  ����    �F�ydouble�zfreq
        //  �ߒl    �F�ystring�z
        //  ����    �F 2011/02/09 kida
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

        #region �w�肵���A�v���P�[�V�������I��������B(�t�@�C�����S�̂��w��)
        //----------------------------------------------------
        //  �֐�    �FExecStopApp
        /// <summary>  �w�肵���A�v���P�[�V�������I��������B(�t�@�C�����S�̂��w��)
        /// </summary>
        /// <param name="app_name">�Ώۂ̃t�@�C����</param>
        /// <param name="wait">�I���҂�����(msec)</param>
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
                    foreach (Process p in app_proc)      //��x���ʂɏI��点��B
                    {
                        if (p.Id != my_process.Id)
                        {
                            Debug.WriteLine(p.Id);
                            p.CloseMainWindow();
                            p.WaitForExit(wait);
                        }
                    }
                    app_proc = Process.GetProcessesByName(app_name);
                    foreach (Process p in app_proc)      //�c���Ă����狭���I���B
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

        #region �w�肵��������Ŏn�܂�A�v���P�[�V���������ׂďI��������B(�t�@�C�����̐擪�����̕�������w��)
        //----------------------------------------------------
        //  �֐�    �FExecStopAllApp
        /// �w�肵��������Ŏn�܂�A�v���P�[�V���������ׂďI��������B(�t�@�C�����̐擪�����̕�������w��)
        /// </summary>
        /// <param name="app_name">�Ώۂ̃t�@�C����(".exe"���܂܂Ȃ����O�B15�����ȉ�)</param>
        /// <param name="wait">�I���҂�����(msec)</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool ExecStopAllApp(string app_name, int wait)
        {
            try
            {
                Process my_process = Process.GetCurrentProcess();
                Process[] all_process = Process.GetProcesses();
                foreach (Process p in all_process)      //��x���ʂɏI��点��B
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
                foreach (Process p in all_process)      //�c���Ă����狭���I���B
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

        #region �����񒆂Ɏw�肵���p�^�[���ƈ�v����ӏ����擾����
        //----------------------------------------------------
        //  �֐�    �FGetStringFromMessage
        /// ������̒��Ɏw�肵���p�^�[���ƈ�v����ӏ����擾����
        /// </summary>
        /// <param name="pattern">���K�\��</param>
        /// <param name="msg">�������镶����</param>
        /// <param name="response">�Y������������</param>
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
            //������v������G���[�Ƃ���
            if (m.Success)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region �����񒆂Ɏw�肵�������Ԃ̕�������擾����
        //----------------------------------------------------
        //  �֐�    �FGetBetweenStrings
        /// 2�̕�����̊Ԃ̕������Ԃ�
        /// </summary>
        /// <param name="str1">1�ڂ̕���</param>
        /// <param name="str2">2�ڂ̕���</param>
        /// <param name="str2">���o���ꂽ����</param>
        /// <returns>true:Success false:Failure</returns>
        //----------------------------------------------------
        public static bool GetBetweenStrings(string str1, string str2, string orgStr, out string hitstrings)
        {
            int orgLen = orgStr.Length; //�����̕�����̒���        
            int str1Len = str1.Length; //str1�̒���                    
            int str1Num = orgStr.IndexOf(str1); //str1�������̂ǂ̈ʒu�ɂ��邩        
            hitstrings = ""; //�Ԃ�������   

            //��O����       
            try
            {
                hitstrings = orgStr.Remove(0, str1Num + str1Len); //�����̏��߂���str1�̂���ʒu�܂ō폜                
                int str2Num = hitstrings.IndexOf(str2); //str2��s�̂ǂ̈ʒu�ɂ��邩                
                hitstrings = hitstrings.Remove(str2Num); //s��str2�̂���ʒu����Ō�܂ō폜        
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
