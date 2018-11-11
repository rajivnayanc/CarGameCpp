//Nayan's Logic
#include <iostream>
#include <Windows.h>
#include <cstdlib>
#include <ctime>
#include <conio.h>
using namespace std;

void clearscreen(); //used to prevent flicker

int main()
{
  char map[25][25];

    //loads the map with spaces and borders
    for(int i=0; i < 20; ++i) {
      for(int j=0; j < 20; ++j) {
        map[i][0] = '|';
        map[i][18] = '|';
        map[i][j] = ' ';
      }
    }

    int y = 17, x = 9; //the cars coordinates
    srand(time(0));
    int a = 0, b = rand() % 15 + 2; //the obstacles coordiantes
    int points = 0; //points that the player has earned
    int speed = 100; //determines the speed of the obstacles (and the car)
    int q = 0, p = rand() % 15 + 2; //the cash coordinates
    int cashcheck = 0; //balances when the cash spawns
    int cashpickedup = 0;
    bool startup = true;

    char cash = '$';
    char obstacle = 219;

    char car = 'X';
    map[y][x] = car;
    //the game loop
    for(;;) {
      clearscreen();
        //places the car at its default location
        map[y][x] = 'X';
        map[y][x+1] = '|';
        map[y][x-1] = '|';
        map[y+1][x-1] = 'o';
        map[y+1][x+1] = 'o';
        map[y-1][x-1] = 'o';
        map[y-1][x+1] = 'o';

      //generates the obstacles
      	map[a][b] = ' ';
        map[a][b] = ' ';
        map[a][b+1] = ' ';
        map[a][b-1] = ' ';
        map[a+1][b-1] = ' ';
        map[a+1][b+1] = ' ';
        map[a-1][b-1] = ' ';
        map[a-1][b+1] = ' ';
        ++a;
        map[a][b] = obstacle;
        map[a][b+1] = obstacle;
        map[a][b-1] = obstacle;
        map[a+1][b-1] = obstacle;
        map[a+1][b+1] = obstacle;
        map[a-1][b-1] = obstacle;
        map[a-1][b+1] = obstacle;
        if(a > 20) {
          a = 0;
          b = rand() % 15 + 2;
        }
    //displays the map
    for(int i=0; i < 20; ++i) {
      for(int j=0; j < 20; ++j) {
        cout << map[i][j];
          if(j >= 19) {
            cout << endl;
          }
        }
      }
    cout << "    Points: " << points + (cashpickedup*30);
    //does so the game starts after a key is pressed
    if(startup) {
      _getch();
      startup = false;
    }
    //moves the car to the left
    if(GetAsyncKeyState(VK_LEFT)) {
      if(map[y][x-3] == obstacle) {
        goto lost;
      }
      else if(map[y][x-3] != '|') {
        map[y][x] = ' ';
        map[y][x+1] = ' ';
        map[y][x-1] = ' ';
        map[y+1][x-1] = ' ';
        map[y+1][x+1] = ' ';
        map[y-1][x-1] = ' ';
        map[y-1][x+1] = ' ';
        x -= 3;
        map[y][x] = 'X';
        map[y][x+1] = '|';
        map[y][x-1] = '|';
        map[y+1][x-1] = 'o';
        map[y+1][x+1] = 'o';
        map[y-1][x-1] = 'o';
        map[y-1][x+1] = 'o';
      }
    }
    //moves the car to the right
    if(GetAsyncKeyState(VK_RIGHT)) {
      if(map[y][x+3] == obstacle) {
        goto lost;
      }
      else if(map[y][x+3] != '|') {
        map[y][x] = ' ';
        map[y][x+1] = ' ';
        map[y][x-1] = ' ';
        map[y+1][x-1] = ' ';
        map[y+1][x+1] = ' ';
        map[y-1][x-1] = ' ';
        map[y-1][x+1] = ' ';
        x += 3;
        map[y][x] = 'X';
        map[y][x+1] = '|';
        map[y][x-1] = '|';
        map[y+1][x-1] = 'o';
        map[y+1][x+1] = 'o';
        map[y-1][x-1] = 'o';
        map[y-1][x+1] = 'o';
      }
    }
    //checks if the car crashed
    if(map[y-2][x] == obstacle || map[y-2][x-1] == obstacle || map[y-2][x+1] == obstacle) {
lost:
      cout << "\n\nYou crashed!\n" << endl;
      cin.get();
      return 0;
    }
    //checks if the player picked up cash
    if(map[y-2][x] == cash || map[y-2][x-1] == cash || map[y-2][x+1] == cash) {
      map[y-2][x] = ' ';
      map[y-2][x-1] = ' ';
      map[y-2][x+1] = ' ';
      ++cashpickedup;
      q = 0;
      p = rand() % 15 + 2;
    }
    //generates the cash
    else if(q > 20) {
      q = 0;
      p = rand() % 15 + 2;
    }
    //does so the cash doesnt appear next to the obstacle
    if(a > 8) {
      ++cashcheck;
    }
    //places the cash
    if(cashcheck) {
    map[q][p] = ' ';
    ++q;
    map[q][p] = cash;
    }
      ++points;
    //speeds up the obstacles each time the player gets another 100 points
    if(points == 100 || points == 200 || points == 300 || points == 400) {
        speed -= 25;
      }
    Sleep(speed);
    }
  return 0;
}

void clearscreen()
{
    HANDLE hOut;
    COORD Position;

    hOut = GetStdHandle(STD_OUTPUT_HANDLE);

    Position.X = 0;
    Position.Y = 0;
    SetConsoleCursorPosition(hOut, Position);
}
