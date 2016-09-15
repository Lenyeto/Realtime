#ifndef _APPLICATION_H_
#define _APPLICATION_H_
#include "LogManager.h"

namespace ssuge {
	
	///Application States
	enum ApplicationState { UNINITIALIZED, RUNNING, SHUTTING_DOWN };
	
	///Class for the Application
	class Application
	{
		
	/*! Member Variables */
	private:
		///LogManager Pointer
		LogManager * mLogManager;
		///SDL Window
		SDL_Window * mWindow; 
		///The current state of the application. Defaults is UNINITIALIZED
		ssuge::ApplicationState mCurrentState = UNINITIALIZED;
		
	/*! Constructors */
	public:
		///Initializes the Application class
		Application():mWindow(NULL),mLogManager(NULL) { initialize(); };

	/*! Deconstructors */
	public:
		///Cleans up the instance of the Application when destoryed 
		~Application(){ shutdown(); }

	/*! Methods */
	private:
		///Initializes the Window and LogManager
		void initialize();
		///Handles events 
		void handleEvent();
		///Shuts down the application and cleans up some stuff
		void shutdown();
	public:
		///Main Loop
		void run();
	};
}


#endif