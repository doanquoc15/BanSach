//Hàm hiển thị ảnh
function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.file && imageUploader.file[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.file[0]);
    }
}