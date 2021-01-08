//738
#include<iostream>
#include<vector>
using namespace std;
class Solution {
public:
    int num[40],len;
    int ans[40];
    void dfs(int pos,int pre,int op)
    {
        //op==1 代表当前位置的值小于等于后面位置的值,  pos-1 代表后面的位置，pos+1代表前面的位置
        //op==0 代表当前位置的值大于后面位置的值,  pre 记录和当前位置的数相等的前面的数的个数

        if(pos<0)
        return ;

        if(op)
        {
            ans[pos] = num[pos];

            if(num[pos]==num[pos-1])
            dfs(pos-1,pre+1,(num[pos]<=num[pos-1]));
            else if(num[pos]<num[pos-1])
            {
            dfs(pos-1,0,(num[pos]<=num[pos-1]));
            }
            else 
            dfs(pos-1,pre,(num[pos]<=num[pos-1]));
        }
        else{
            ans[pos+pre]=num[pos+pre]-1;
            for(int i = pos+pre-1;i>=0;i--)
            {
                ans[pos] = 9;
            }
            return;
        }
    }
    int monotoneIncreasingDigits(int N) {
        len =0;
        while(N)
        {
            num[len++]= N%10;
            N/=10;
        }
        int res = 0;
        while(len)
        {
            res+=num[len]*pow(10,len);
            len--;
        }

        return res;
    }
};