# 引入Speech SDK
from aip import AipSpeech

# 定义常量
APP_ID = '10435093'
API_KEY = 'RjfPmEGG87GWaNlKLg8Xap3o'
SECRET_KEY = 'e291bce5b33418cea79cff67693c79e8'

# 初始化AipSpeech对象
aipSpeech = AipSpeech(APP_ID, API_KEY, SECRET_KEY)

# 读取文件
def get_file_content(filePath):
    with open(filePath, 'rb') as fp:
        return fp.read()

# 识别本地文件
res = aipSpeech.asr(get_file_content('16k.wav'), 'wav', 16000, {
    'lan': 'zh',
})

print(res)
