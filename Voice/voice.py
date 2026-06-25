import speech_recognition as sr
import socket
import cv2
import threading

# 은수님 노트북 IP/PORT
HOST = "192.168.0.17"
PORT = 8000

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((HOST, PORT))
print(f"연결 성공: {HOST}:{PORT}")

r = sr.Recognizer()

# 음성인식 스레드
def voice_thread():
    with sr.Microphone() as source:
        r.adjust_for_ambient_noise(source)
        print("말하세요...")
        while True:
            try:
                audio = r.listen(source, timeout=5)
                text = r.recognize_google(audio, language="ko-KR")
                print(f"인식됨: {text}")
                for char in text:
                    msg = f"VOICE:{char}\n"
                    sock.sendall(msg.encode("utf-8"))
            except sr.WaitTimeoutError:
                continue
            except sr.UnknownValueError:
                print("인식 실패")
            except:
                break

# 음성인식 백그라운드로 실행
t = threading.Thread(target=voice_thread, daemon=True)
t.start()

# 카메라 화면
cap = cv2.VideoCapture(0)

while True:
    ret, frame = cap.read()
    if not ret:
        break
    cv2.imshow("내 카메라", frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()
sock.close()