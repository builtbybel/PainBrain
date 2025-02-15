# WinRecall

**WinRecall** is a local and portalble desktop application that periodically captures screenshots of your screen, uses AI (via [BLIP](https://github.com/salesforce/BLIP)) to generate detailed descriptions for each image, and allows you to search and retrieve those screenshots based on their generated descriptions—all running locally on your machine.

This project started as a personal tool to archive documents using Tesseract OCR. Over time, I supercharged it with a deep learning model to generate rich, natural-language descriptions of screen captures. For anyone who doesn’t want to splurge on a Copilot+PC (the only way to get the original Microsoft Recall), this replica is available for you to test right on your desktop!


![WinRecallApp_DdXXQX9YtK](https://github.com/user-attachments/assets/29f4b608-8d4e-4cc8-a721-6d70cc85a606)

---

## Features

### Automated Screenshot Capture
Periodically captures your screen (every few seconds) and saves the images in a dedicated folder.

### AI-Powered Image Descriptions
Uses **BLIP** (via the Hugging Face Transformers library) to generate detailed, natural-language descriptions for every screenshot. It's like giving your screen captures a voice!

### Local Search & Retrieval
Indexes the screenshot file paths, AI-generated descriptions, and timestamps in a local SQLite database, making it super easy to search and retrieve past captures based on keywords. Find your screenshots without any hassle.

---
## How It Works

1. **Capture Mode:**
   - The app currently **captures only the main screen** at regular intervals (every few seconds).
   
2. **Processing & Description:**
   - After each screenshot is captured, **it may take a few seconds** for the app to generate an AI-powered description using the BLIP model. During this time, the app processes the image and creates a textual description.
   
3. **Indexing for Search:**
   - Once the description is generated, it is **indexed and stored** in a local SQLite database along with the file path and timestamp of the screenshot. This enables you to easily search and find screenshots later based on keywords from the descriptions.

4. **Control the Capture Process:**
   - **Start the process** by clicking the "Capture" button. This begins the periodic screenshot capturing and description generation.
   - **Stop the process** by clicking the "Stop" button at any time. This halts the screenshot capturing.

5. **Database Management:**
   - You can **clear the database** anytime via the option at the bottom-right of the app.
   - **Adjust image previews** to fit your preferences.

---

## How to Run

Before running the app, simply execute the provided `setup.bat` file. This batch file will:

1. Check if Python is installed.
2. If Python isn't found, it will guide you through the installation process.
3. Upgrade `pip` and install the required packages.

If Python is already set up, just run `WinRecallApp.exe` and you’re good to go!

---

## Installation

Simply run the provided `setup.bat` file to install everything you need to get WinRecall up and running.

The batch script will:
1. Check if Python is installed on your system.
2. If Python is not installed, it will download and install Python, **automatically adding it to your PATH** (ensure the "Add Python to PATH" option is selected during installation).
3. Upgrade `pip` to the latest version.
4. Install all required Python packages (`transformers`, `torch`, `pillow`).

If you'd prefer to manually install the dependencies, you can do so by running the following commands in your terminal:

```bash
pip install transformers torch pillow


