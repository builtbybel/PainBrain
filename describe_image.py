import os
import sqlite3
from transformers import BlipProcessor, BlipForConditionalGeneration
from PIL import Image

def describe_image(image_path, db_path):
    try:
        # Initialize the model and processor
        processor = BlipProcessor.from_pretrained("Salesforce/blip-image-captioning-base")
        model = BlipForConditionalGeneration.from_pretrained("Salesforce/blip-image-captioning-base")

        # Open the image and process it
        raw_image = Image.open(image_path).convert("RGB")
       # print(f"Processing image: {image_path}")
        text = "a photography of"
        inputs = processor(raw_image, text, return_tensors="pt")

        # Generate the description
        out = model.generate(**inputs)
        description = processor.decode(out[0], skip_special_tokens=True)
        print(f"Generated Description: {description}")

        # Save the description to a text file (in the same folder as the image)
       # description_file = f"{image_path}.description.txt"
       # with open(description_file, 'w') as f:
        #    f.write(description)
        
       # print(f"Description for {image_path}: {description}")

        # Save the description to the database
        conn = sqlite3.connect(db_path)
        cursor = conn.cursor()

        # Insert the description into the database
        cursor.execute('''
            UPDATE snapshots
            SET description = ?
            WHERE filepath = ?
        ''', (description, image_path))

        conn.commit()
        conn.close()

        return description

    except Exception as e:
        print(f"Error processing image {image_path}: {e}")
        return None

def describe_all_images_in_folder(folder_path, db_path):
    # Check if the folder exists
    if not os.path.exists(folder_path):
        print(f"Error: The folder {folder_path} does not exist.")
        return
    
    # Loop through all images in the folder
    for filename in os.listdir(folder_path):
        if filename.startswith("decrypted_snapshot_") and filename.endswith(".jpg"):
            image_path = os.path.join(folder_path, filename)
            print(f"Describing image: {image_path}")
            describe_image(image_path, db_path)

# Get the current directory where the script is located (one level above the snapshots folder)
current_directory = os.path.dirname(os.path.abspath(__file__))
snapshots_folder = os.path.join(current_directory, "snapshots")  # Folder where snapshots are located
db_path = os.path.join(current_directory, "snapshots.db")  # Path to the SQLite database

# Check if the folder exists and process images
if os.path.exists(snapshots_folder):
    describe_all_images_in_folder(snapshots_folder, db_path)
else:
    print(f"The 'snapshots' folder was not found in the directory: {current_directory}")
