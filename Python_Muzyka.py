class Track:
    def __init__(self, title, artist):
        self.title = title
        self.artist = artist


class Playlist:
    def __init__(self, name):
        self.name = name
        self.tracks = []

    def add_track(self, track):
        self.tracks.append(track)

    def remove_track(self, title):
        for i in range(len(self.tracks)):
            if self.tracks[i].title == title:
                self.tracks.pop(i)
                break

    def play(self):
        print("Odtwarzanie playlisty: " + self.name)
        for i in range(len(self.tracks)):
            print("-> Grane teraz: " + self.tracks[i].title + " - " + self.tracks[i].artist)


class User:
    def __init__(self, username):
        self.username = username
        self.playlists = []

    def create_playlist(self, name):
        nowa = Playlist(name)
        self.playlists.append(nowa)
        return nowa


if __name__ == "__main__":
    user = User("Kuba")

    piosenka1 = Track("Bohemian Rhapsody", "Queen")
    piosenka2 = Track("Smooth Criminal", "Michael Jackson")

    moja_lista = user.create_playlist("Moje Hity")

    moja_lista.add_track(piosenka1)
    moja_lista.add_track(piosenka2)

    moja_lista.play()

    moja_lista.remove_track("Smooth Criminal")

    moja_lista.play()