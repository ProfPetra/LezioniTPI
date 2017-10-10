var video,img;
var snapshots=[];
 var w=150;
 var h=150;
 var x=0;
 var y=0;



function setup(){
 
 createCanvas(2000,1000);
 background(51);
 video=createCapture(VIDEO);
 img=loadImage("polaroid.png")
}



function draw(){
 
 frameRate(3);


image(video,x,y,w,h);
 
 //image(img,x,y,w,h)

 //image(video,x+10,y+10,w*0.88,h*0.72);
 
 /*push();


 translate(x,y);
 


 rotate(random(-PI/10,PI/10));

 
 var point=random(-img.width/1.8,-img.width/2.2);
 
 image(img,point,0,w,h)

 image(video,point+10,10,w*0.88,h*0.72);
 
 pop()
 */


 x+=w;
 if (x>width-w){
 	x=0;
 	y+=h;
 	}
if (y>height-h){
	x=0;
	y=0;
	}


 


}






