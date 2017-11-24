import sys  
import wave  

def printparams(file_path):
    f = wave.open(file_path,"rb")  
    #read the wave's format infomation,and return a tuple  
    params = f.getparams()  
    #get the info  
    nchannels, sampwidth, framerate, nframes = params[:4]  

    print("channels: ", nchannels)
    print("sampwidth: ", sampwidth)
    print("framerate: ", framerate)
    print("nframes: ", nframes)


if __name__ == "__main__":  
    if len(sys.argv) < 2:
        print("Show wave file parameters.\n\nUsage: %s filename.wav" % sys.argv[0])
        sys.exit(-1)
    printparams(sys.argv[1])
