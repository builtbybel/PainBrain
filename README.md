# PaneBrain 
(ProjectMnemonic)

This project is a portable, native app that records your screen, no data sent to Microsoft, just your privacy intact. . Think of it as an alternative to Microsoft's Recall. Not perfect yet, but cool if you need to capture and analyze your screen without any strings attached.  So while it’s not a Microsoft Recall, it’s still got that recall vibe ( this is the first release) – all without the scary data-hungry vibes. And trust me, you can count on this. 

Technical details: While the app uses Hugging Face’s BLIP model for cloud processing, it also works offline, with all OCR tasks handled completely locally by Tesseract. 

Right now, I’m running this project under the name **“PaneBrain”** or **“Panebrain”** . And just to make sure, I'm avoiding any potential issues with MS by not using **WinRecall** as the final name. 😉

What started as my personal tool for archiving documents using **Tesseract OCR** has evolved over time with a deep learning model to generate rich, natural-language descriptions of your screenshots. So, if you don’t want to spend a fortune on a Copilot+PC (the only way to get Microsoft Recall), this is your **open-source** alternative.

![PaneBrainApp](https://github.com/user-attachments/assets/29f4b608-8d4e-4cc8-a721-6d70cc85a606)

---

## How It Works

1. **Capture & Process:** The app **captures your main screen** at regular intervals.  
2. **AI Descriptions:** Each screenshot is analyzed, and a detailed **text description** is generated.  
3. **Search & Retrieve:** Screenshots and their descriptions are indexed in a local **SQLite database**, making them searchable by keywords.  
4. **Controls:** Hit **"Capture"** to start, **"Stop"** to pause, and manage your saved images through the database settings.  

---

## Installation

Run **PaneBrainApp.exe**, then click the **"Setup Environment"** button in the bottom left corner.

1. The app will automatically install Python (if needed) and set up all the required dependencies.
2. Once everything’s set up, restart the pc and you’re good to go!

---

### Manual Installation (Optional)

If you prefer to install everything manually, here are the steps:  

1. Install [Python](https://www.python.org/downloads/) (make sure to check **"Add Python to PATH"** during installation).  
2. Open a terminal and run:  

```
   python -m pip install --upgrade pip
   pip install transformers torch pillow
```

<details>
<summary> (Optional) Run BLIP Image Captioning Model Locally</summary>

### 1. Clone the BLIP Model Repository

Fork and clone the BLIP model from Hugging Face:

```
git clone https://huggingface.co/Salesforce/blip-image-captioning-base
```
### 2. Modify describe_image.py
In Panebrain/describe_image.py file, change lines 9-10 to load the model locally:

```
processor = BlipProcessor.from_pretrained("./blip-image-captioning-base")
model = BlipForConditionalGeneration.from_pretrained("./blip-image-captioning-base")
```
This will use the locally downloaded files instead of fetching the model from the cloud.
</details>
