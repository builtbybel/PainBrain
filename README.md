# **WinRecall**

**WinRecall** is a lightweight and portable desktop app that captures screenshots, uses AI ([BLIP](https://github.com/salesforce/BLIP)) to generate detailed descriptions, and lets you search your captures effortlessly, all running locally on your machine.  

This project started as my personal tool to archive documents using Tesseract OCR. Over time, I supercharged it with a deep learning model to generate rich, natural-language descriptions of your screen captures.  If you don’t want to spend big on a Copilot+PC (the only way to get Microsoft Recall), this is your open alternative..

![WinRecallApp](https://github.com/user-attachments/assets/29f4b608-8d4e-4cc8-a721-6d70cc85a606)  

---

## **Features**  

- **Automatic Screenshot Capture** – Periodically captures your screen and saves the images.  
- **AI-Powered Descriptions** – Uses **BLIP** to generate rich, natural-language descriptions.  
- **Instant Search** – Find screenshots easily via keyword-based search.  
- **Local & Private** – Everything runs **on your device**, no cloud processing.  

---

## **How It Works**  

1. **Capture & Process:** The app **captures your main screen** at regular intervals.  
2. **AI Descriptions:** Each screenshot is analyzed, and a detailed **text description** is generated.  
3. **Search & Retrieve:** Screenshots and descriptions are indexed in a local **SQLite database**, making them searchable by keywords.  
4. **Controls:** Click **"Capture"** to start, **"Stop"** to pause, and manage saved images via the database settings.  

---

## **Installation**  

Run **WinRecallApp.exe** and click **"Setup Environment"** if Python is missing. The setup will:  

1. Start **WinRecallApp.exe**.
2. If Python is missing, click the **"Setup Environment"** button in the bottom left corner.
3. The app will automatically install Python (if needed) and set up all required dependencies.
4. Once the setup is complete, restart the app and you're ready to go!

### **Manual Installation (Optional)**  

If you prefer, you can install everything manually by following these steps:  

1. Install [Python](https://www.python.org/downloads/) (ensuring that **"Add Python to PATH"** is selected).  
2. Open a terminal and run:  

   ```bash
   python -m pip install --upgrade pip
   pip install transformers torch pillow
