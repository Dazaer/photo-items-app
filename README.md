# photo-items-app
An application to manage photos of a particular item depending on its property. For example: photos of ring items where they're sorted by metal type and shape.

Made as an exercise in less than a week testing .NET Core and frontend capabilities.

## Instructions to run project:
- Inside BackendPhotoItemsApp folder run command `dotnet run`
- Inside frontend-photo-items-app run command `yarn serve`
- Open website on http://localhost:8080/

Things to consider about this project:
- A database is not provided, but the sql creation script is in Scripts folder. Insert your database fields correctly in appsettings.json and run the script.
- If using firefox browser must go to https://localhost:5001 and accept certificate, or else won't be able to access api.
- The image restriction although easily removed through the database, I consistently coded around it as it is declared as such in the Sql script.

### Project comments

The database has `Types` which were not explained as to what they are. I assumed they would be the actual Photo and the Thumbnail, but the data inserted doesn't match:

The same ring (with id 1) has 4 PhotoItems. 2 photos and 2 thumbnails
- Photo 1: Round, **Yellow gold** (changed to Rose Gold)
- Photo 2: Cushion, Yellow gold
- Thumb 1: Round, Rose gold
- Thumb 2: Cushion, **Rose gold** (changed to Yellow Gold)

Switching the values of ItemPhotoPropertySet with ids 1 and 7, as shown, makes things make sense again. 

### Missing features

Although the project exercise according to the instructions given is finished here are some features I'd like to implement with a bit more time:

- Show quantities of each item/shape/metal inside the select
- Add images by loading image from desktop and save as byte data?
  - Research into best practices and most efficient ways to store image files in database
- I dislike that upon Including entities, even though NewtonsoftJson stops circular referencing, the entity still brings data that should be stopped by the Dto
  - Research more into ways of stopping circular referencing and passing only data that is needed. Can Automapper ever accomplish this?
- Metal and Shape should be database tables with their proper values, and not just virtual data.
- Maybe implement a Service layer to help abstract Controllers from relying on Automapper, but the drawback is there's a lot more code to go through.
- Research into implementing Unit of Work, is it worth the trouble?
- A way to run all project with just one command, api and vue.
- Readjust styling and adaptability to different screens.
- Add loading indication when fetching.
- Only save photos, but automatically compress image and add it as thumbnail. However this actually might slow things down more...
