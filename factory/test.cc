#include<iostream>
using namespace std;
#include<vector>
class Solution {
public:
    int canCompleteCircuit(vector<int>& gas, vector<int>& cost) {
        int n = gas.size();
        
        int start = -1;
        int total_tank =0;
        int curr_tank = 0;

        for(int i=0;i<n;i++)
        {
            curr_tank += gas[i]-cost[i];
            total_tank += gas[i]-cost[i];
            if(curr_tank<0)
            {
                curr_tank = 0;
                start=i+1;
            }
        }

        if(total_tank<0) return -1;
        return start;

    }
};