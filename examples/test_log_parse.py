
import json
import re
def inst_nas_log_query(message = 'Attach accept',pattern=r'T3412[^\)]*\)'):
    
    data_list = inst_log_query('NAS',message)
    #r'T3412[^\)]*\)'

    for data in data_list:
        m = re.search(pattern,data)
        if m:
            print(data)
            return m.group(0)
            
                

    
def inst_log_query(Layer = 'RRC', Value ='Attach accept',start_time = None, stop_time = None):
    try:
        
        container =[]
        log_list = inst_log_get_list_by_timestamp(start_time,stop_time)   
        
        for log in log_list:
            if log.get('layer')  == Layer :
                for data in log.get('data'):
                    if data.find(Value) != -1:
                        container.append(''.join(log.get('data')))
        
        return container

    except:
        raise

def inst_log_get_list_by_timestamp(start_time = None,stop_time = None):
    """
    Return a list within the interval from start_time to stop time.
    if start_time and stop_time is None return the whole list
    """
    try:
        log_list =[]
        with open("log_get.json") as f:
            results = json.load(f)
            if start_time is None:
                log_list = results
            elif stop_time is None:
                for result in results:
                    if result['timestamp']  > start_time :
                        log_list.append(result)
            else:
                for result in results:
                    if result['timestamp']  > start_time and result['timestamp'] <= stop_time:
                        log_list.append(result)
        return log_list

    except:
        raise