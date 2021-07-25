import requests
import time

from requests.models import Response
# defining the api-endpoint 
API_ENDPOINT = 'xxxxxx'
import paramiko

def create_uhost():
    create_uhost_request = {}
    # sending post request and saving response as response object
    r = requests.post(url = API_ENDPOINT, json = create_uhost_request)
    # extracting response text 
    return r.json()

def terminate(uhost_id):
    terminate_request =  { 
    }
    # sending post request and saving response as response object
    r = requests.post(url = API_ENDPOINT, json = terminate_request)
    # extracting response text 
    return r.json()

def start_uhost(uhost_id):
    start_uhost_request = {
    }

    # sending post request and saving response as response object
    r = requests.post(url = API_ENDPOINT, json = start_uhost_request)
    # extracting response text 
    return r.json()

def reinstall(uhost_id):
    reinstall_request = {
    }


    # sending post request and saving response as response object
    r = requests.post(url = API_ENDPOINT, json = reinstall_request)
    # extracting response text 
    return r.json()


def reinstall_test():
    round = 1
    while True:
        print(round)
        uhost_id = 'xxx-xx'
        response = power_off(uhost_id)
        print(response)
        if response["RetCode"] == 0:
            time.sleep(30)
            response = reinstall(uhost_id)
            print(response)
            if response["RetCode"] == 0:
                time.sleep(30)
                ssh = paramiko.SSHClient()
                ssh.load_system_host_keys()
                username = 'root'
                password = 'xxxx'
                server = 'xxxxx'
                time.sleep(100)
                ssh.connect(server, username=username, password=password)
                get_mount_info = 'sshpass -p "xxxx" ssh -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null root@10.23.185.30 "cd /root; df -hT > mount_info.log"'
                ssh_stdin, ssh_stdout, ssh_stderr = ssh.exec_command(get_mount_info)
                time.sleep(20)

                copy_ping_dig_command = "sshpass -p 'xxxx' scp -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null 10.23.185.30:/root/* ."

                ssh_stdin, ssh_stdout, ssh_stderr = ssh.exec_command(copy_ping_dig_command)

                check_mount_info_command = "cat mount_info.log | grep NFS"
                ssh_stdin, ssh_stdout, ssh_stderr = ssh.exec_command(check_mount_info_command)
                time.sleep(10)
                lines = ssh_stdout.readlines()
                print(lines)
                if len(lines) == 0:
                    print(f'nfs mount failed {round}')
                    break
                else:
                    print(f'nfs mount succeed {round}')
                    print(lines)
        round += 1



if __name__ == '__main__':
    reinstall_test()