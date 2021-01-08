class Solution {
public:
    struct Dwell{
        int row;
        int column;
        int trigger;

        Dwell(int r,int c, int t):row(r),column(c),trigger(t){ }
    };

    vector<string> maze;
    static constexpr int dir[2][4] = { {1, 0, -1, 0} , {0, 1, 0, -1}};
    int rowNum;
    int columnNum;
    int dfs(int row, int column, vector< vector<bool>> v) {
        if(maze[row][column] == 'O' ) {
            return 1;
        }

        int res = 1e8;

        for (int i = 0; i < 4; i++) {
            int newRow = row + dir[0][i];
            int newColumn = column + dir[1][i];

            if(newRow >= 0 && newRow < rowNum && newColumn >= 0 && newColumn < columnNum) {
                if(!v[newRow][newColumn] && maze[newRow][newColumn] != '#') {
                    v[newRow][newColumn] = 1;
                    res = min(res, dfs(newRow,newColumn, v) + 1);
                    v[newRow][newColumn] = 0;
                }
            }
        }
        return res;
    }
    int minimalSteps(vector<string>& maze) {
        this->maze = maze;

        if(maze.size() == 0 || maze[0].size() == 0) return -1;
        rowNum = maze.size();
        columnNum = maze[0].size();

        int start_row = -1;
        int start_column = -1;
        int trigger_num = 0;
        int dist[100][100][100];
        bool v[100][100][100];
        for (int row = 0; row < rowNum; row++) {
            for (int column = 0; column < columnNum; column++) {
                if(maze[row][column] == 'M')
                    ++trigger_num;
                else if(maze[row][column] == 'S') {
                    start_row = row;
                    start_column = column;
                }

            }
        }
        memset(v, 0, sizeof(v));
        memset(dist, 0, sizeof(dist));
        queue<Dwell> Q;

        Q.emplace(start_row, start_column, 0);
        v[start_row][start_column][0] = 1;
        dist[start_row][start_column][0] = 1;
        queue<Dwell> NQ;
        while(!Q.empty()) {
            while(!Q) {
                auto dwell = Q.front();
                Q.pop();
                int row =  dwell.row;
                int column = dwell.column;
                int trigger = dwell.trigger;

                for (int i = 0; i < 4; i++) {
                    int newRow = row + dir[0][i];
                    int newColumn = column + dir[1][i];

                    if (newRow >= 0 && newRow < rowNum && newColumn >= 0 && newColumn < columnNum) {
                        if (!v[newRow][newColumn][trigger] && maze[newRow][newColumn] != '#') {
                            
                            if(maze[row][column] == 'M') {
                                vector< vector<bool> > visited(rowNum, vector<bool> (columnNum, 0));
                                int move = dfs(row,columnNum,visited);
                                if(move == 1e8) return -1;
                                dist[newRow][newColumn][trigger + 1] = dist[row][column][trigger] + (move - 1) * 2 + 1;
                                Q.emplace(newRow, newColumn, trigger + 1);
                            }
                            else if(maze[row][column] == 'T' && trigger == trigger_num) {
                                return dist[row][column][trigger] + 1;
                            }
                            else {
                                v[newRow][newColumn][trigger] = 1;
                                dist[newRow][newColumn][trigger]  = dist[row][column][trigger] + 1;
                                Q.emplace(newRow, newColumn, trigger);
                            }
                        }
                    }
                }
            }

            Q = NQ;
        }

        return -1;
    }
};