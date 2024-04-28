#include <iostream>
#include <random>

using namespace std;

void xorshift(uint32_t& value, vector<uint32_t>& PsevdRand) {
    value ^= (value << 13);
    value ^= (value >> 17);
    value ^= (value << 5);
    PsevdRand.push_back(value);
}

int main() {
    vector<uint32_t> PsevdRand;
    uint32_t value = 12345678;
    for (int i = 0; i < 10; i++) {
        xorshift(value, PsevdRand);
    }
    for (uint32_t n : PsevdRand) {
        cout << n << " ";
    }
    cout << endl;
    return 0;
}
