#include "stdafx.h"
#include "Application.h"

///Initializes the application
void ssuge::Application::initialize()
{
	///Creates a new log manager
	mLogManager = new ssuge::LogManager("../../tmp/Debug/log.txt");//outputs the log in our /tmp/Debug folder
	///Adds to the log that the window is being created
	mLogManager->log("Initializing Window");
	///Tries to create the window
	mWindow = SDL_CreateWindow("Lab03_wb", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 800, 600, SDL_WINDOW_SHOWN);
	///Logs if the window was crated or failed and what error it had
	if (mWindow == NULL)
	{
		mLogManager->log(SDL_GetError(),LL_ERROR);
		shutdown();
		
	}
	else
	{
		mLogManager->log("Window created");
		mCurrentState = ssuge::RUNNING;
	}
}


///Shuts down the application, and logs it and deletes the log manager.
void ssuge::Application::shutdown()
{
	mLogManager->log("Shutting down application");
	delete mLogManager;
	SDL_Quit();
}


///Takes the events for closing the application
void ssuge::Application::handleEvent()
{
	SDL_PumpEvents();
	if(SDL_HasEvent(SDL_QUIT) || SDL_GetKeyboardState(NULL)[SDL_SCANCODE_ESCAPE])
	{
		mCurrentState = ssuge::SHUTTING_DOWN;
	}
}


///The running loop for the application, handles events for now
void ssuge::Application::run()
{
	while (mCurrentState == ssuge::RUNNING)
	{
		handleEvent();
	}

}







