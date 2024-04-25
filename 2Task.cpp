#include <iostream>
#include <random>
#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

int main() {
    random_device rd;
    mt19937_64 random_(rd());
    //1-2
    int N = 10;
    vector<int> randNum;

    for (int i = 0; i < N; i++) {
        randNum.push_back(random_()%101 + 100);
    }
    sort(randNum.begin(), randNum.end());
    cout << "Массив с случайными значениями: ";
    for (int n : randNum) {
        cout << n << " ";
    }
    cout << endl;
    cout << "Второй по величине элемент: " << randNum[N-2] << endl;
    int sum = 0;
    randNum.pop_back();
    randNum.pop_back();
    randNum.erase(randNum.begin());
    for (int i : randNum) {
        sum += i;
    }
    cout << "Сумма: " << sum << endl;

    randNum.clear();
    //3
    vector<int> randNum1;
    vector<int> New;

    for (int i = 0; i < N; i++) {
        randNum.push_back(random_()%101 - 50);
    }

    for (int i = 0; i < N; i++) {
        randNum1.push_back(random_()%101 - 50);
    }

    int ind = 0;
    for (int n : randNum) {
        if (ind % 2 == 0) {
            New.push_back(n + randNum1[ind]);
        }
        else {
            New.push_back(n - randNum1[ind]);
        }
        ind++;
    }
    cout << "Первый массив с случайными значениями: ";
    for (int n : randNum) {
        cout << n << " ";
    }
    cout << endl;
    cout << "Второй массив с случайными значениями: ";
    for (int n : randNum1) {
        cout << n << " ";
    }
    cout << endl;
    cout << "Новый массив: ";
    for (int n : New) {
        cout << n << " ";
    }
    cout << endl;
    unordered_map<int, int> povtor;
    for (int n : New) {
        povtor[n]++;
    }
    for (pair<int, int> n : povtor) {
        cout << "Элемент: " << n.first << " Количество повторов: " << n.second << endl;
    }
    int a, b;
    cout << "Введите начальный и конечный год: ";
    cin >> a >> b;
    vector<int> visokYears;
    for (int i = a; i <= b; i++) {
        if (i%4 == 0) {
            visokYears.push_back(i);
        }
    }
    cout << "Високосные годы: ";
    for (int n : visokYears) {
        cout << n << " ";
    }
    return 0;
}
