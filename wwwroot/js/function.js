

function toggleBtn(){ 
    var btn = document.getElementById("btn");
    var ghost = document.getElementById("ghost")
    var kratos = document.getElementById("kratos")
    var line = document.getElementById("line")
    var single = document.getElementById("single")
    var multi = document.getElementById("multi")

    btn.classList.toggle("active");
    ghost.classList.toggle("on");
    kratos.classList.toggle("off");
    line.classList.toggle("activeline");
    single.classList.toggle("off");
    multi.classList.toggle("on");    
}

// gallery

var fullImgBox = document.getElementById("fullImgBox");
var fullImg = document.getElementById("fullImg");

function openFullImg(pic){
    fullImg.src = pic;
    fullImgBox.style.display = "flex";
}

function closeFullImg(){
    fullImgBox.style.display = "none";
}

var imgs = ["http://localhost/GameSnipe/images/thor.jpg", "http://localhost/GameSnipe/images/conor.jpg", "http://localhost/GameSnipe/images/elden-ring.webp", 
            "http://localhost/GameSnipe/images/fh5.jpg", "http://localhost/GameSnipe/images/Stray.jpg", "http://localhost/GameSnipe/images/2042.jpg"]


function nextImg(){
    var i = imgs.indexOf(fullImg.src) + 1;
    if(i >= imgs.length){
        i = 0;
    }
    var s = imgs[i];
    closeFullImg();
    openFullImg(s);
}

function prevImg(){
    var i = imgs.indexOf(fullImg.src) - 1;
    if(i < 0){
        i = imgs.length - 1;
    }
    var s = imgs[i];
    closeFullImg();
    openFullImg(s);
}

function downloadImg(){
    const anchor = document.createElement('a');
    anchor.href = fullImg.src;
    anchor.download = "img.jpg";
    document.body.appendChild(anchor);
    anchor.click();
    document.body.removeChild(anchor);
}
