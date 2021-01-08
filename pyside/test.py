from ctypes import *
import os
from midt_mtk_wrapper import *
import argparse


def main():
    parser = argparse.ArgumentParser(prog='Murata Firmware Download Tool',description='Murata Firmware Download Tool CLI')
    parser.add_argument('-p','--port', required=False, default = 'COM3', help='com port name as a interface to connect the target, default is COM3')
    parser.add_argument('-f','--cfg',  required=False, default = '..\\fw\\modem\\flash_download.cfg', help='Firmware download configuration file')
    parser.add_argument('-t','--target',  required=False, default = '1YS',help='Target DUT name, default is 1YS')
    operation_group = parser.add_mutually_exclusive_group()
    operation_group.add_argument("-w", "--write", help="write the firmware into DUT", action="store_true")
    operation_group.add_argument("-r", "--read", help="read the firmware from DUT and as as binary file", action="store_true")
    operation_group.add_argument("-e", "--erase", help="erase the DUT", action="store_true")
    group = parser.add_mutually_exclusive_group()
    group.add_argument('--save_name', required=False, default = 'readback.bin', help='readback file name only used in -r or --read operation')
    group.add_argument('--nvdm_name', required=False, default = 'nvdm.bin', help='nvdm file name only used in -e or --erase operation')
    parser.add_argument('--addr',  required=False, default = '-1',help='Must start with 0x, The start address used in --erase or --read')
    parser.add_argument('--len',  required=False, default = '-1',help='Must start with 0x, The length used in --erase or --read')
    args = vars(parser.parse_args())
    port = args['port']
    if args['write'] or args['read'] or args['erase']:
        print('write:',args['write'])
        print('read:',args['read'])
        print('erase:',args['erase'])
    else:
        print('Please assign one operation [read, write or erase]')
    cfg_file = ""
    #print(args)
    if os.path.isabs(args['cfg']):
        cfg_file = args['cfg']
    else:
        cfg_file = os.path.normpath(os.getcwd()+os.altsep+args['cfg'])
    da_path = os.path.normpath(os.getcwd()+os.altsep+'libs\\mtk\\MTK_AllInOne_DA.bin')
    if not os.path.exists(cfg_file):
        print('the config file ',cfg_file,'is not existed')
    print(cfg_file)
    midt_mtk = MIDT_MTK_WRAPPER()
    if args['write']:
        midt_mtk.midt_connect_target(port,da_path,cfg_file)
        print("status ",midt_mtk.mtk_apis.get_last_api_status())
        midt_mtk.midt_download_fw(cfg_file)
        print("status ",midt_mtk.mtk_apis.get_last_api_status())
        midt_mtk.midt_disconnect_target()
        print("status ",midt_mtk.mtk_apis.get_last_api_status())
    if args['read']:
        print(args['addr'])
        print(args['len'])
        if args['addr'] == '-1' or args['addr'] == '-1':
            print("Please assign addr and length when read back")
        else:
            if args['addr'].find('0x') >= 0 or args['addr'].find('0X') >= 0 or args['len'].find('0x') >= 0 or args['len'].find('0X') >= 0:
                midt_mtk.midt_connect_target(port,da_path,cfg_file)
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
                midt_mtk.midt_read_back(os.path.normpath(os.getcwd()+os.altsep+'rdbk.bin'),int(args['addr'],0),int(args['len'],0))
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
                midt_mtk.midt_disconnect_target()
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
            else:
                print('--addr and --length must start with 0x')
    if args['erase']:
        print(args['addr'])
        print(args['len'])
        if args['addr'] == '-1' or args['len'] == '-1':
            print("a total format without NVDM will be actived")
            midt_mtk.midt_connect_target(port,da_path,cfg_file)
            print("status ",midt_mtk.mtk_apis.get_last_api_status())
            midt_mtk.midt_format_flash(FORMAT_TYPE.TOTAL_FLASH_FORMAT_WITHOUT_NVDM,os.path.normpath(os.getcwd()+os.altsep+'nvdm.bin'),0,0)
            print("status ",midt_mtk.mtk_apis.get_last_api_status())
            midt_mtk.midt_disconnect_target()
            print("status ",midt_mtk.mtk_apis.get_last_api_status())
        else:
            if args['addr'].find('0x') >= 0 or args['addr'].find('0X') >= 0 or args['len'].find('0x') >= 0 or args['len'].find('0X') >= 0:
                print("This is a custom format with address and length")
                midt_mtk.midt_connect_target(port,da_path,cfg_file)
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
                midt_mtk.midt_format_flash(FORMAT_TYPE.TOTAL_FLASH_FORMAT_CUST,'',int(args['addr'],0),int(args['len'],0))
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
                midt_mtk.midt_disconnect_target()
                print("status ",midt_mtk.mtk_apis.get_last_api_status())
            else:
                print('--addr and --length must start with 0x')
