#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <map>
#include <queue>
#include <math.h>
#include <charconv>
#include <sstream>
using namespace std;

class ParkingSystem
{
private:
    int capacities[4], maxCapacity[4];

public:
    ParkingSystem(int big, int medium, int small)
    {
        maxCapacity[1] = big;
        maxCapacity[2] = medium;
        maxCapacity[3] = small;
        capacities[1] = capacities[2] = capacities[3] = 0;
    }

    bool addCar(int carType)
    {
        if (capacities[carType] == maxCapacity[carType])
        {
            return false;
        }
        ++capacities[carType];
        return true;
    }
};

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem* obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj->addCar(carType);
 */
//////////////////
bool AreEqual(vector<int> v1, vector<int> v2)
{
    if (v1.size() != v2.size())
    {
        return false;
    }
    for (int i = 0; i < v1.size(); i++)
    {
        if (v1[i] != v2[i])
        {
            return false;
        }
    }
    return true;
}
void printArray(vector<int> arr)
{
    for (int i = 0; i < arr.size(); i++)
    {
        cout << arr[i] << endl;
    }
}

int main()
{
    return 0;
}
