CXX=g++
CFLAGS=-std=c++11 -I/home/anl/include/ -I/home/anl/include/GLFW/ -I/usr/include -I/usr/local/include
MAC_FRAMEWORKS=-framework Cocoa -framework IOKit -framework CoreVideo -framework OpenGL
LIBS=-lglfw3 -lGLEW -lpthread ${MAC_FRAMEWORKS}
#linux: -lGl -lGLU -lX11 -lXxf86vm -lXrandr -lXi
PLIKI_FROM=main.o ./common/shader.o
DO_ZLINKOWNIA=main.o shader.o

default: show

.cpp.o:
	${CXX} -c ${CFLAGS} $<

show: ${PLIKI_FROM}
	${CXX} -L/home/anl/libs/ ${DO_ZLINKOWNIA} -o show  ${COMMON} ${LIBS}

clean:
	rm *o show
