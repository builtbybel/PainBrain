# Winrecall 
(ProjectMnemonic)

This project is a portable, native app that records your screen, no data sent to Microsoft, just your privacy intact. . Think of it as an alternative to Microsoft's Recall. Not perfect yet, but cool if you need to capture and analyze your screen without any strings attached.  While it’s not quite Microsoft Recall, it still offers a similar experience (this is the first release).

Technical details: While the app uses Hugging Face’s BLIP model for cloud processing, it also works offline, with all OCR tasks handled completely locally by Tesseract.

Currently, I’m running this project under the name "Winrecall".

What started as my personal tool for archiving documents using Tesseract OCR has evolved into a deep learning model that generates rich, natural-language descriptions of your screenshots.

So, if you don’t want to invest in a Copilot+ PC (which is the only way to access Microsoft Recall, as those devices are equipped with the necessary NPU for AI-intensive tasks), this open-source alternative gives you a taste of the Copilot+ PC experience without the hefty investment.

![WinrecallApp](https://github.com/user-attachments/assets/29f4b608-8d4e-4cc8-a721-6d70cc85a606)

---

## How It Works

1. **Capture & Process:** The app **captures your main screen** at regular intervals.  
2. **AI Descriptions:** Each screenshot is analyzed, and a detailed **text description** is generated.  
3. **Search & Retrieve:** Screenshots and their descriptions are indexed in a local **SQLite database**, making them searchable by keywords.  
4. **Controls:** Hit **"Capture"** to start, **"Stop"** to pause, and manage your saved images through the database settings.  

---

## Installation

Run **WinrecallApp.exe**, then click the **"Setup Environment"** button in the bottom left corner.

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
In Winrecall/describe_image.py file, change lines 9-10 to load the model locally:

```
processor = BlipProcessor.from_pretrained("./blip-image-captioning-base")
model = BlipForConditionalGeneration.from_pretrained("./blip-image-captioning-base")
```
This will use the locally downloaded files instead of fetching the model from the cloud.
</details>
