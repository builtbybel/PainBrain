# WinRecall

**WinRecall** is a local and portalble desktop application that periodically captures screenshots of your screen, uses AI (via [BLIP](https://github.com/salesforce/BLIP)) to generate detailed descriptions for each image, and allows you to search and retrieve those screenshots based on their generated descriptions—all running locally on your machine.

This project started as a personal tool to archive documents using Tesseract OCR. Over time, I supercharged it with a deep learning model to generate rich, natural-language descriptions of screen captures. For anyone who doesn’t want to splurge on a Copilot+PC (the only way to get the original Microsoft Recall), this replica is available for you to test right on your desktop!

---

## Features

### 🖼Automated Screenshot Capture
Periodically captures your screen (every few seconds) and saves the images in a dedicated folder.

### AI-Powered Image Descriptions
Uses **BLIP** (via the Hugging Face Transformers library) to generate detailed, natural-language descriptions for every screenshot. It's like giving your screen captures a voice!

### Local Search & Retrieval
Indexes the screenshot file paths, AI-generated descriptions, and timestamps in a local SQLite database, making it super easy to search and retrieve past captures based on keywords. Find your screenshots without any hassle.

---

## How to Run

Before running the app, simply execute the provided `setup.bat` file. This batch file will:

1. Check if Python is installed.
2. If Python isn't found, it will guide you through the installation process.
3. Upgrade `pip` and install the required packages.

If Python is already set up, just run `WinRecallApp.exe` and you’re good to go!

---

## Requirements

- **Python 3.x**  
  Required to run the image description script.

**Python Packages:**

- **transformers**: Provides access to modern deep learning models like BLIP.
- **torch**: The deep learning framework (PyTorch) that powers the model.
- **Pillow**: A powerful imaging library for Python.

---

## Installation

Simply run the provided `setup.bat` file to install everything you need to get WinRecall up and running. If you prefer, you can install the dependencies manually by running:

```bash
pip install transformers torch pillow
