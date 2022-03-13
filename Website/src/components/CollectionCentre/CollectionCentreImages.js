import { Fragment, useState, React } from "react";
import { useForm } from "react-hook-form";
import classes from "./CollectionCentreImages.module.css";
import ImageUploading from "react-images-uploading";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const CollectionCentreImages = (props) => {
  const [images, setImages] = useState([]);
  const maxNumber = 8;

  const onChange = (imageList, addUpdateIndex) => {
    console.log(imageList, addUpdateIndex);
    setImages(imageList);
  };
  const update = () => {
    createApiEndpoint(ENDPOINTS.Images)
      .create(images)
      .catch((err) => console.log(err));
  };
  return (
    <Fragment>
      <ImageUploading
        multiple
        value={images}
        onChange={onChange}
        maxNumber={maxNumber}
        dataURLKey="data_url"
      >
        {({
          imageList,
          onImageUpload,
          onImageUpdate,
          onImageRemove,
          isDragging,
          dragProps,
        }) => (
          <div className={classes.Wrapper}>
            <button
              style={isDragging ? { color: "red" } : undefined}
              onClick={onImageUpload}
              className={classes.DragArea}
              {...dragProps}
            >
              Kliknij lub przeciągnij do 8 zdjęć
            </button>
            &nbsp;
            <div className={classes.ImageContainer}>
              {imageList.map((image, index) => (
                <div key={index} className={classes.ImageCard}>
                  <img src={image["data_url"]} alt="" width="200" />
                  <div>
                    <button
                      className={classes.Buttons}
                      onClick={() => onImageUpdate(index)}
                    >
                      Aktualizuj
                    </button>
                    <button
                      className={classes.Buttons}
                      onClick={() => onImageRemove(index)}
                    >
                      Usuń
                    </button>
                  </div>
                </div>
              ))}
            </div>
          </div>
        )}
      </ImageUploading>
      <button className={classes.Buttons} onClick={() => update()}>
        wyslij
      </button>
    </Fragment>
  );
};

export default CollectionCentreImages;
