
#include <iostream>
#include <SDL.h>
#include "LogManager.h"



int main()
{

	SDL_Window *window;
	SDL_Init(SDL_INIT_VIDEO);

	window = SDL_CreateWindow("Lab03_wb", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 800, 600, 0);

	if (window == NULL) {
		//cout << "Could not create window" << endl;
		return 0;
	}

	while (1) {
		
	}

    return 0;
}

