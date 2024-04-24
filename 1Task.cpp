#include <iostream>
#include <cmath>
#include <fstream>
#include <iomanip>
#include <vector>
#include <tuple>

using namespace std;

double f(double x) {
    return x * log(x + 1) - 1;
}

double df(double x) {
    return log(x + 1) + x / (x + 1);
}

double g(double x) {
    if (x < 0.0) return exp(1.0/x) - 1;
    else return 1.0/log(x+1);
}

void bisectionMethod(double a, double b, double eps, vector<tuple<double, double, double, double>>& bisection, double& res) {
    int N = 0;
    while ((b - a) >= eps && N < 100) {
        double c = (a + b) / 2;
        bisection.push_back({N, a, b, b - a});
        if (f(c) == 0) {
            break;
        } 
        else if (f(a) * f(c) < 0) {
            b = c;
        } 
        else {
            a = c;
        }
        N++;
        res = c;
    }
}

void NewtonMethod(double x0, double eps, vector<tuple<double, double, double, double>>& newton, double& res) {
    int N = 0;
    while (abs(f(x0)) >= eps && N < 100) {
        double x1 = x0 - f(x0) / df(x0);
        double razn = abs(x1 - x0);
        if (razn < 0.0001) razn = 0.0001;
        newton.push_back({N, x0, x1, razn});
        if (abs(x1 - x0) <= eps) {
            break;
        }
        x0 = x1;
        N++;
        res = x0;
    }
}

void simpleMethod(double x0, double eps, vector<tuple<double, double, double, double>>& simple, double& res) {
    int N = 0;
    while (abs(g(x0)) >= eps && N < 100) {
        double x1 = g(x0);
        if (abs(x1 - x0) < eps) {
            break;
        }
        simple.push_back({N, x0, x1, abs(x1 - x0)});
        x0 = x1;
        N++;
        res = x0;
    }
}

int main() {
    double a = -1, b = 2, eps = 0.0001;
    double res;
    vector<tuple<double, double, double, double>> bisection;
    vector<tuple<double, double, double, double>> newton;
    vector<tuple<double, double, double, double>> simple;

    ofstream outfile("FunctionsResult.txt");
    if (!outfile.is_open()) {
        cout << "При открытии файла произошла ошибка" << endl;
        return 1;
    }
    //Первый корень
    bisectionMethod(a, b, eps, bisection, res);
    outfile << "Метод половинного деления(первый корень):" << endl;
    outfile << "N" << setw(20) << "a" << setw(20) << "b" << setw(20) << "b - a" << endl;
    for (tuple<double, double, double, double> i : bisection) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    outfile << endl;
    double x0 = -0.5;
    NewtonMethod(x0, eps, newton, res);
    outfile << "Метод Ньютона(первый корень):" << endl;
    outfile << "N" << setw(20) << "x0" << setw(20) << "x1" << setw(20) << "x1 - x0" << endl;
    for (tuple<double, double, double, double> i : newton) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    outfile << endl;
    simpleMethod(x0, eps, simple, res);
    outfile << "Метод простых итераций(первый корень):" << endl;
    outfile << "N" << setw(20) << "x0" << setw(20) << "x1" << setw(20) << "x1 - x0" << endl;
    for (tuple<double, double, double, double> i : simple) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    outfile << endl;
    outfile << "--------------------------------------------------------------" << endl;
    //Второй корень
    bisection.clear();
    newton.clear();
    simple.clear();
    a = 0, b = 2;
    bisectionMethod(a, b, eps, bisection, res);
    outfile << "Метод половинного деления(Второй корень):" << endl;
    outfile << "N" << setw(20) << "a" << setw(20) << "b" << setw(20) << "b - a" << endl;
    for (tuple<double, double, double, double> i : bisection) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    outfile << endl;
    x0 = 0.5;
    NewtonMethod(x0, eps, newton, res);
    outfile << "Метод Ньютона(Второй корень):" << endl;
    outfile << "N" << setw(20) << "x0" << setw(20) << "x1" << setw(20) << "x1 - x0" << endl;
    for (tuple<double, double, double, double> i : newton) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    outfile << endl;
    simpleMethod(x0, eps, simple, res);
    outfile << "Метод простых итераций(Второй корень):" << endl;
    outfile << "N" << setw(20) << "x0" << setw(20) << "x1" << setw(20) << "x1 - x0" << endl;
    for (tuple<double, double, double, double> i : simple) {
        outfile << get<0>(i) << setw(20) << get<1>(i) << setw(20) << get<2>(i) << setw(20) << get<3>(i) << endl;
    }
    outfile << endl;
    outfile << "Корень: " << res << endl;
    return 0;
}