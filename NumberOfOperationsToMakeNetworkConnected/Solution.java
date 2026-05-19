package NumberOfOperationsToMakeNetworkConnected;

import java.util.HashSet;

class Solution {
    public int makeConnected(int n, int[][] connections) {
        if (connections.length < n - 1) {
            return -1;
        }

        int[] subnetworkIds = new int[n];
        int a, b;
        for (int i = 0; i < subnetworkIds.length; i++) {
            subnetworkIds[i] = i;
        }

        for (int[] connection : connections) {
            a = connection[0];
            b = connection[1];
            mergeNetworks(subnetworkIds, a, b);
        }

        int numOfClusters = getNumberOfClusters(subnetworkIds);

        return numOfClusters - 1;
    }

    private int getNetworkRepresentative(int[] subnetworkIds, int pos) {
        if (subnetworkIds[pos] == pos) {
            return pos;
        }
        return subnetworkIds[pos] = getNetworkRepresentative(subnetworkIds, subnetworkIds[pos]);
    }

    private int getNumberOfClusters(int[] subnetworkIds) {
        var clusters = new HashSet<Integer>();
        for (int i = 0; i < subnetworkIds.length; i++) {
            clusters.add(getNetworkRepresentative(subnetworkIds, i));
        }
        return clusters.size();
    }

    private void mergeNetworks(int[] subnetworkIds, int a, int b) {
        int networkIdA = getNetworkRepresentative(subnetworkIds, a);
        int networkIdB = getNetworkRepresentative(subnetworkIds, b);
        int newRepresentative = Math.min(networkIdA, networkIdB);
        subnetworkIds[a] = subnetworkIds[b] = subnetworkIds[networkIdA] = subnetworkIds[networkIdB] = newRepresentative;
    }
}