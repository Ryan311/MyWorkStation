#!usr/bin/env python  
#coding=utf-8  

import sys  
import wave  
import matplotlib.pyplot as plt  
import numpy as np  
  
def read_wave_data(file_path):  
    #open a wave file, and return a Wave_read object  
    f = wave.open(file_path,"rb")  
    #read the wave's format infomation,and return a tuple  
    params = f.getparams()  
    #get the info  
    nchannels, sampwidth, framerate, nframes = params[:4]  
    #Reads and returns nframes of audio, as a string of bytes.   
    str_data = f.readframes(nframes)  
    #close the stream  
    f.close()  
    #turn the wave's data to array  
    wave_data = np.fromstring(str_data, dtype = np.int16)  
    #for the data is stereo,and format is LRLRLR...  
    #shape the array to n*2(-1 means fit the y coordinate)  
    #for 2 channels
    if nchannels == 2:
        wave_data.shape = -1, 2
        wave_data = wave_data.T
        time = np.arange(0, nframes) * (1.0 / framerate)
    else:
        wave_data.shape = -1, 1
        time = np.arange(0, nframes) * (1.0 / framerate)
    #calculate the time bar  
    time = np.arange(0, nframes) * (1.0/framerate)  
    return nchannels, wave_data, time  
  
def waveplot(wavefile):  
    nchans, wave_data, time = read_wave_data(wavefile)
    #draw the wave  
    if nchans == 2:
        plt.subplot(211)  
        plt.plot(time, wave_data[0])  
        plt.subplot(212)  
        plt.plot(time, wave_data[1], c = "g")  
    else:
        plt.subplot(111)  
        plt.plot(time, wave_data)  
    plt.xlabel("time (seconds)")
    plt.show()
  
if __name__ == "__main__":  
    if len(sys.argv) < 2:
        print("Plays a wave file.\n\nUsage: %s filename.wav" % sys.argv[0])
        sys.exit(-1)
    waveplot(sys.argv[1])
