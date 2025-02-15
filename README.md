# WinRecall

**WinRecall** is a local and portalble desktop app that periodically captures screenshots of your screen, uses AI (via [BLIP](https://github.com/salesforce/BLIP)) to generate detailed descriptions for each image, and allows you to search and retrieve those screenshots based on their generated descriptions

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

# **How to Run**

1. Start **WinRecallApp.exe**.
2. If Python is missing, click the **"Setup Environment"** button in the bottom left corner.
3. The app will automatically install Python (if needed) and set up all required dependencies.
4. Once the setup is complete, restart the app and you're ready to go!

---

## **Installation (Automatic Setup)**

Just start the app and click **"Setup Environment"** if prompted.  
The setup will:  

- ✅ Check if Python is installed.  
- ✅ Install Python (if missing) and **automatically add it to PATH** (make sure to select "Add Python to PATH" during installation).  
- ✅ Upgrade `pip` to the latest version.  
- ✅ Install all required Python packages (`transformers`, `torch`, `pillow`).  

---

## **Manual Installation (Optional)**

If you prefer, you can install everything manually by following these steps:  

1. Check if Python is installed on your system.  
2. If Python is not installed, [download and install it](https://www.python.org/downloads/), ensuring that **"Add Python to PATH"** is selected.  
3. Open a terminal or command prompt and upgrade `pip`:  

   ```bash
   python pip install transformers torch pillow



