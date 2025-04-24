# KANAVRT

KANAVRT is a Blazor WebAssembly application designed to help users learn and practice Kana characters (Japanese syllabary). It provides tools for managing Kana character sets, tracking performance statistics, and engaging in interactive quizzes.

---

## Features

### 1. Quizzes
#### Either-Or Quiz
- **Route**: `/quiz/eitheror`
- **Purpose**: Test your ability to distinguish between two Kana characters.
- **How It Works**:
  - Select the correct Kana character from two options.

#### Keyboard Quiz
- **Route**: `/quiz/keyboard`
- **Purpose**: Practice typing Kana characters using a keyboard or syllable buttons.
- **How It Works**:
  - Type the correct Kana character based on the prompt.

### 2. Grid Settings
- **Route**: `/settings/grid`
- **Purpose**: Configure Kana character sets, including Monographs, Digraphs, and their diacritic variations.
- **Key Features**:
  - Toggle between Monographs and Digraphs using radio buttons.
  - View Kana character sets in a responsive table.

### 3. Statistics View
- **Route**: `/statistics`
- **Purpose**: Visualize performance statistics for each Kana characters.
- **Key Features**:
  - Expandable categories (Monographs, Digraphs, Diacritic Monographs, Diacritic Digraphs).
  - Progress bars showing correct and incorrect answers for each Kana character.
  - Color-coded statistics for easy interpretation.

---

## Systems Manual

### Setup Instructions

#### Prerequisites
- Install the latest version of **.NET 8 SDK**.
- Install **Visual Studio 2022** with the Blazor WebAssembly workload.

#### Installation
1. Clone the repository
2. Open the solution (kanavrt.sln) in Visual Studio
3. Build and run the project (green triangle button with 'https' next to it)

### KANAVRT system

### System Parts

The system is divided into several parts, each responsible for different functionalities based on the MVC design pattern.

#### - **Model**
- **Purpose**: Represents the data of the game logic in the application.
- **Key Components**:
  - **KanaModel**: Represents all Kana characters together with their latin form and pronunciation.
  - **Statistics/StatisticsModel**: Stores the number of correct and wrong guesses for each playable glyth.
  - **Settings/***: Represents the settings of the application.
	- **SettingsModel**: Stores the current settings, i.e. current font and set of characters.
	- **Grid/Table/***: Table models used in grid settings containing row, column, vowel and consonants-based sets.
	  - **AbstractTableModel**: Abstract class for creating different table models.
	  - **MonographTableModel**: Represents the table model for monographs.
	  - **DigraphTableModel**: Represents the table model for digraphs.
	  - **DiacriticMonographTableModel**: Represents the table model for diacritic monographs.
	  - **DiacriticDigraphTableModel**: Represents the table model for diacritic digraphs.

#### - **View**
- **Purpose**: Represents the user interface of the application.
- **Key Components**:
  - **HomeView.razor**: The body page of each page view.

  - **MainNavView.razor**: The main navigation component for single page.

  - **Quiz/***: Blazor components representing quizes.
	- **QuizView.razor**: Helper component for redirecting to main quiz mode (EitherOrView).
	- **QuizSideNavView.razor**: Component for displaying quiz page side navigation.
	- **EitherOr/EitherOrView.razor**: Page for the either-or quiz.
	- **Keyboard/KeyboardView.razor**: Page for the keyboard quiz.
	- **ProgressBarView.razor**: Component for displaying quiz progress bar.

  - **Settings/***: Blazor components representing settings.
	- **SettingsView.razor**: Helper component for redirecting to main settings page (GridView).
	- **SettingsSideNavView.razor**: Component for displaying settings page side navigation.
	- **Fonts/FontsView.razor**: Page for font settings.
	- **Grid/***: Blazor components representing grid settings.
	  - **GridView.razor**: Page for grid settings.
	  - **Table/***: Page for displaying the grid table components.
		- **AbstractTableView.razor**: Abstract class for creating different table view components.
		- **MonographTableView.razor**: Page for displaying the monograph table component.
		- **DigraphTableView.razor**: Page for displaying the digraph table component.
		- **DiacriticMonographTableView.razor**: Page for displaying the diacritic monograph table component.
		- **DiacriticDigraphTableView.razor**: Page for displaying the diacritic digraph table component.

  - **Statistics/StatisticsView.razor**: Page for displaying statistics for each character in the form of wrong/correct guesses.

  - **ErrorView.razor**: Page for displaying error messages.

#### - **Controller**
- **Purpose**: Represents the logic of the application quizes and intermediate between Views and Models.
- **Key Components**:
  - **Quiz/***: Blazor components representing quiz logic.
	- **AbstractQuizController**: Abstract class for creating different quiz controllers and their game logic.
	- **EitherOrQuizController**: Controller for the either-or quiz.
	- **KeyboardQuizController**: Controller for the keyboard quiz.
