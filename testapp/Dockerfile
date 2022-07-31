#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



COPY k8svc.pfx /app/k8svc.pfx


RUN apt-get update && \
    apt-get install --no-install-recommends -y \
        #whois \
        arptables \
        bridge-utils \
        ca-certificates \
        conntrack \
        curl \
        runc \
        nano \
        dnsutils \
        ethtool \
       # iperf \
       # iperf3 \
        iproute2 \
        ipset \
        iptables \
        iputils-ping \
        jq \
        kmod \
        ldap-utils \
        less \
        libpcap-dev \
        man \
       # manpages-posix \
        mtr \
        net-tools \
        netcat \
        netcat-openbsd \
        openssl \
        openssh-client \
        psmisc \
        socat \
        tcpdump \
        telnet \
        tmux \
        traceroute \
        tcptraceroute \
        tree \
        ngrep \
       # vim \
        wget && \
    rm -rf /var/lib/apt/lists/* && \
   # mv /usr/sbin/tcpdump /usr/bin/tcpdump && \
    mv /usr/sbin/traceroute /usr/bin/traceroute

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["testapp/testapp.csproj", "testapp/"]
RUN dotnet restore "testapp/testapp.csproj"
COPY . .
WORKDIR "/src/testapp"
RUN dotnet build "testapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testapp.dll"]