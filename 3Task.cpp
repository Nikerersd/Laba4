#include <iostream>
#include <vector>
#include <random>
#include <cmath>

using namespace std;

void randomFill(vector<int>& fillVec) {
    random_device rd;
    mt19937_64 random_(rd());

    for (int& n : fillVec) {
        n = random_() % 100 + 1;
    }
}

int CountEl(const vector<int>& vec, int element) {
    int count = 0;
    for (const int& el : vec) {
        if (el == element) count++;
    }
    return count;
}

double realExp(const vector<int>& vec) {
    double sum = 0.0;
    for (int n : vec) {
        sum += n;
    }
    return sum / vec.size();
}

double expectedExp(const vector<int>& vec) {
    double sum = 0.0;
    for (int n : vec) {
        sum += n;
    }
    return sum / 125.0;
}

double Dispersion(const vector<int>& vec) {
    double mathReal = realExp(vec);
    double sum = 0.0;
    for (int value : vec) {
        sum += pow(value - mathReal, 2);
    }
    return sum / (vec.size() - 1);
}

double Laplas(double i) {
    return 0.5 * (1.0 + erf(i / sqrt(2.0)));
}

double chiKv(const vector<int>& vec) {
    double result = 0.0;
    double mathReal = realExp(vec);
    double Dispers = sqrt(Dispersion(vec));

    for (int i = 1; i <= 125; i++) {
        double realIncidence = CountEl(vec, i);
        double expIncidence = vec.size() * (Laplas((i - mathReal) / Dispers) - Laplas((i - 1 - mathReal) / Dispers));
        result += pow(realIncidence - expIncidence, 2) / expIncidence;
    }
    return result;
}

int main() {
    vector<int> vector50(50), vector100(100), vector1000(1000);
    randomFill(vector50);
    randomFill(vector100);
    randomFill(vector1000);

    double crit = 156.69; // Для 125 ст. своб. и ур. знач 0,05

    // 50 значений
    double chiKvZnach = chiKv(vector50);
    double mathReal = realExp(vector50);
    double mathExp = expectedExp(vector50);

    cout << "Значение Хи-квадрата: " << chiKvZnach << endl;
    if (chiKvZnach <= crit) {
        cout << "Гипотеза о нормальном распределении выборки верна." << endl;
    } else {
        cout << "Гипотеза о нормальном распределении выборки неверна." << endl;
    }
    cout << "Ожидаемое математическое ожидание: " << mathExp << endl;
    cout << "Реальное математическое ожидание: " << mathReal << endl << endl;

    // 100 значений
    chiKvZnach = chiKv(vector100);
    mathReal = realExp(vector100);
    mathExp = expectedExp(vector100);

    cout << "Значение Хи-квадрата: " << chiKvZnach << endl;
    if (chiKvZnach <= crit) {
        cout << "Гипотеза о нормальном распределении выборки верна." << endl;
    } else {
        cout << "Гипотеза о нормальном распределении выборки неверна." << endl;
    }
    cout << "Ожидаемое математическое ожидание: " << mathExp << endl;
    cout << "Реальное математическое ожидание: " << mathReal << endl << endl;

    // 1000 значений
    chiKvZnach = chiKv(vector1000);
    mathReal = realExp(vector1000);
    mathExp = expectedExp(vector1000);

    cout << "Значение Хи-квадрата: " << chiKvZnach << endl;
    if (chiKvZnach <= crit) {
        cout << "Гипотеза о нормальном распределении выборки верна." << endl;
    } else {
        cout << "Гипотеза о нормальном распределении выборки неверна." << endl;
    }
    cout << "Ожидаемое математическое ожидание: " << mathExp << endl;
    cout << "Реальное математическое ожидание: " << mathReal << endl << endl;
    
    return 0;
}
