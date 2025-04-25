# KANAVRT

KANAVRT is a Blazor WebAssembly application designed to help users learn and practice Kana characters (Japanese syllabary). It provides tools for managing Kana character sets, tracking performance statistics, and engaging in interactive quizzes.

--

## Features

### 1. Home
- **Route**: `/`
- **Purpose**: The main entry point of the application.
- **Key Features**:
  - Navigation to different sections of the application.
  - Overview of the application and its purpose.
  - Links to social media and GitHub repository.

### 2. Quizzes
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

### 3. Settings
#### Grid Settings
- **Route**: `/settings/grid`
- **Purpose**: Configure Kana character sets, including Monographs, Digraphs, and their diacritic variations.
- **Key Features**:
  - Toggle between Monographs and Digraphs using radio buttons.
  - View Kana character sets in a responsive table.

#### Font Settings
- **Route**: `/settings/font`
- **Purpose**: Configure Kana font used in quiz.
- **Key Features**:
  - Toggle between 9 different fonts based on reading difficulty.
  - View Kana character in font.

### 4. Statistics View
- **Route**: `/statistics`
- **Purpose**: Visualize performance statistics for each Kana characters.
- **Key Features**:
  - Expandable categories (Monographs, Digraphs, Diacritic Monographs, Diacritic Digraphs).
  - Progress bars showing correct and incorrect answers for each Kana character.
  - Color-coded statistics for easy interpretation.


### 5. Contact
#### Contact Information
- **Route**: `/contact/information`
- **Purpose**: Provide contact information for the developers.
- **Key Features**:
  - Display contact information for the developers and address with map.

#### Contact Form
- **Route**: `/contact/form`
- **Purpose**: Allow users to send messages to the developers via email.
- **Key Features**:
  - Form for users to fill out with their name, email, subject and message.
  - Send button to submit the form via email client.

--

## Systems Manual

### Setup Instructions

#### Prerequisites
- Install the latest version of **.NET 8 SDK**.
- Install **Visual Studio 2022** with the Blazor WebAssembly workload.

#### Installation
1. Clone the repository
2. Open the solution (kanavrt.sln) in Visual Studio
3. Build and run the project (green triangle button at top with 'https' next to it)

### KANAVRT system

### System Parts

The system is divided into several parts, each responsible for different functionalities based on the MVC design pattern.

#### - **Model**

- **Route**: `/Model`
- **Purpose**: Represents the data of the game logic in the application.
- **Key Components**:
  - **KanaModel.cs**: Represents all Kana characters together with their latin form and pronunciation.
  - **Statistics/StatisticsModel.cs**: Stores the number of correct and wrong guesses for each playable glyth.
  - **Settings/***: Represents the settings of the application.
    - **SettingsModel.cs**: Stores the current settings, i.e. current font and set of characters.
    - **Grid/Table/***: Table models used in grid settings containing row, column, vowel and consonants-based sets.
      - **AbstractTableModel.cs**: Abstract class for creating different table models.
      - **MonographTableModel.cs**: Represents the table model for monographs.
      - **DigraphTableModel.cs**: Represents the table model for digraphs.
      - **DiacriticMonographTableModel.cs**: Represents the table model for diacritic monographs.
      - **DiacriticDigraphTableModel.cs**: Represents the table model for diacritic digraphs.
- **Directory Overview**
```
Model
|-- Statistics
|   +-- StatisticsModel.cs
|-- KanaModel.cs
+-- Settings
    |-- Grid
    |   +-- Table
    |       |-- DigraphTableModel.cs
    |       |-- AbstractTableModel.cs
    |       |-- MonographTableModel.cs
    |       |-- DiacriticMonographTableModel.cs
    |       +-- DiacriticDigraphTableModel.cs
    +-- SettingsModel.cs
```

#### - **View**

- **Route**: `/View`
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
- **Directory Overview**
```
View
|-- HomeView.razor.css
|-- ErrorView.razor
|-- ErrorView.razor.css
|-- Settings
|   |-- SettingsView.razor
|   |-- SettingsSideNavView.razor
|   |-- Fonts
|   |   |-- FontsView.razor.css
|   |   +-- FontsView.razor
|   +-- Grid
|       |-- GridView.razor.css
|       |-- Table
|       |   |-- AbstractTableView.razor
|       |   |-- DiacriticDigraphTableView.razor.css
|       |   |-- DiacriticMonographTableView.razor.css
|       |   |-- DigraphTableView.razor.css
|       |   |-- MonographTableView.razor.css
|       |   |-- MonographTableView.razor
|       |   |-- DigraphTableView.razor
|       |   |-- DiacriticMonographTableView.razor
|       |   +-- DiacriticDigraphTableView.razor
|       +-- GridView.razor
|-- Contact
|   |-- ContactView.razor
|   |-- ContactSideNavView.razor
|   |-- Form
|   |   |-- FormView.razor.css
|   |   +-- FormView.razor
|   +-- Information
|       |-- InformationView.razor.css
|       +-- InformationView.razor
|-- MainNavView.razor
|-- Quiz
|   |-- QuizSideNavView.razor
|   |-- QuizView.razor
|   |-- ProgressBarView.razor
|   |-- ProgressBarView.razor.css
|   |-- Keyboard
|   |   |-- KeyboardView.razor.css
|   |   +-- KeyboardView.razor
|   +-- EitherOr
|       |-- EitherorView.razor.css
|       +-- EitherorView.razor
|-- HomeView.razor
+-- Statistics
    |-- StatisticsView.razor.css
    +-- StatisticsView.razor
```

#### - **Controller**

- **Route**: `/Controller`
- **Purpose**: Represents the logic of the application quizes and intermediate between Views and Models.
- **Key Components**:
  - **Quiz/***: Blazor components representing quiz logic.
    - **AbstractQuizController**: Abstract class for creating different quiz controllers and their game logic.
    - **EitherOrQuizController**: Controller for the either-or quiz.
    - **KeyboardQuizController**: Controller for the keyboard quiz.
- **Directory Overview**
```
Controller
+-- Quiz
    |-- AbstractQuizController.cs
    |-- EitherOrController.cs
    +-- KeyboardController.cs
```

#### - **Assets**
- **Route**: `/wwwroot`
- **Purpose**: Represents the assets of the application.
- **Key Components**:
  - **css/***: Folder containing the styles used in the application.
  - **js/***: Folder containing javascript code used in the application.
  - **img/***: Folder containing the images used in the application.
  - **font/***: Folder containing the fonts used in the application.
  - **favicon.ico***: Application icon.
  - **index.html**: The main HTML file of the application.
- **Directory Overview**
```
wwwroot
|-- favicon.ico
|-- img
|   +-- svg
|       |-- home
|       |   |-- github.svg
|       |   |-- linkedin.svg
|       |   +-- twitter.svg
|       |-- logo-main.svg
|       |-- settings
|       |   |-- fonts.svg
|       |   |-- fonts_active.svg
|       |   |-- grid.svg
|       |   +-- grid_active.svg
|       |-- quiz
|       |   |-- arrow-clockwise.svg
|       |   |-- eitheror.svg
|       |   |-- eitheror_active.svg
|       |   |-- keyboard.svg
|       |   |-- keyboard_active.svg
|       |   |-- volume-down.svg
|       |   +-- volume-off.svg
|       |-- mainnav
|       |   |-- contact-active.svg
|       |   |-- contact-default.svg
|       |   |-- home-active.svg
|       |   |-- home-default.svg
|       |   |-- settings-active.svg
|       |   |-- settings-default.svg
|       |   |-- statistics-active.svg
|       |   |-- statistics-default.svg
|       |   |-- quiz-active.svg
|       |   +-- quiz-default.svg
|       |-- statistics
|       |   +-- caret-right-fill.svg
|       +-- contact
|           |-- envelope-fill.svg
|           |-- telephone-fill.svg
|           |-- form.svg
|           |-- form_active.svg
|           |-- home-active.svg
|           |-- information.svg
|           +-- information_active.svg
|-- manifest.webmanifest
|-- service-worker.js
|-- font
|   |-- Aoboshi_One
|   |   |-- AoboshiOne-Regular.ttf
|   |   +-- OFL.txt
|   |-- Cherry_Bomb_One
|   |   |-- CherryBombOne-Regular.ttf
|   |   +-- OFL.txt
|   |-- Zen_Kurenaido
|   |   |-- OFL.txt
|   |   +-- ZenKurenaido-Regular.ttf
|   |-- Chokokutai
|   |   |-- Chokokutai-Regular.ttf
|   |   +-- OFL.txt
|   |-- Dela_Gothic_One
|   |   |-- DelaGothicOne-Regular.ttf
|   |   +-- OFL.txt
|   |-- Monomaniac_One
|   |   |-- MonomaniacOne-Regular.ttf
|   |   +-- OFL.txt
|   |-- Hannari
|   |   |-- DESCRIPTION.en_us.html
|   |   |-- Hannari-Regular.ttf
|   |   +-- OFL.txt
|   +-- DotGothic16
|       |-- DotGothic16-Regular.ttf
|       +-- OFL.txt
|-- service-worker.published.js
|-- js
|   +-- focus.js
|-- Ads.txt
|-- sitemap.xml
|-- robots.txt
|-- index.html
+-- css
    |-- sidenav.css
    |-- mainnav.css
    +-- kanavrt.css
```