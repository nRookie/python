/*

1.create a set spns to save spanned tree node which have already be spanned.
an array cost[i] to save  costed value to node i.

2. traverse the adjacent node of the nodes in spns.

3.put the nodes which will produce smallest cost edge into the spnset.
please note the selected node cannot produce a circle.

4. update the cost[i]  if(cost[j]>dist(i,j)+cost[i])


1 0 1
0 0 0
1 0 1

grid[i][j] ,n*n
vis[i][j] , n*n


### 单源最短路径

1.用一个数组d,保存起始节点到结点nx,ny的最短距离.
并使用一个优先队列Q来减少时间复杂度

2.首先遍历grid数组把陆地的下标都添加到Q里面.
并将其相应的最短距离设置为0.


3. 从Q里面弹出一个元素,其必定是最短距离最小的元素.
然后对它邻接的元素进行访问.
若 d[nx][ny]> d[x][y] +1 , 令d[nx][ny] = d[x][y]+1;


4.


*/
 
 