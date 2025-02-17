# **PaneBrain (ProjectMnemonic)**

**PaneBrain** is a lightweight, portable desktop app that captures screenshots, uses AI ([BLIP](https://github.com/salesforce/BLIP)) to generate detailed descriptions, and lets you search through your captures with ease – all running **locally** on your machine.

Right now, I’m running this project under the name **“PaneBrain”** or **“Panebrain”** . And just to make sure, I'm avoiding any potential issues with MS by not using **WinRecall** as the final name. 😉

What started as my personal tool for archiving documents using **Tesseract OCR** has evolved over time with a deep learning model to generate rich, natural-language descriptions of your screenshots. So, if you don’t want to spend a fortune on a Copilot+PC (the only way to get Microsoft Recall), this is your **open-source** alternative.

![PaneBrainApp](https://github.com/user-attachments/assets/29f4b608-8d4e-4cc8-a721-6d70cc85a606)

---

## **Features**  

- **Automatic Screenshot Capture** – Periodically captures your screen and saves the images.  
- **AI-Powered Descriptions** – Uses **BLIP** to generate rich, natural-language descriptions.  
- **Instant Search** – Easily search through your screenshots using keywords.  

---

## **How It Works**  

1. **Capture & Process:** The app **captures your main screen** at regular intervals.  
2. **AI Descriptions:** Each screenshot is analyzed, and a detailed **text description** is generated.  
3. **Search & Retrieve:** Screenshots and their descriptions are indexed in a local **SQLite database**, making them searchable by keywords.  
4. **Controls:** Hit **"Capture"** to start, **"Stop"** to pause, and manage your saved images through the database settings.  

---

## **Installation**  

Run **PaneBrainApp.exe**, then click the **"Setup Environment"** button in the bottom left corner.

1. The app will automatically install Python (if needed) and set up all the required dependencies.
2. Once everything’s set up, restart the pc and you’re good to go!

---

### **Manual Installation (Optional)**  

If you prefer to install everything manually, here are the steps:  

1. Install [Python](https://www.python.org/downloads/) (make sure to check **"Add Python to PATH"** during installation).  
2. Open a terminal and run:  

   ```bash
   python -m pip install --upgrade pip
   pip install transformers torch pillow
