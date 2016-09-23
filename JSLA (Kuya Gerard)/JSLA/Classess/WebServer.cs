using System;
using System.IO;
using System.Net;

public class WebServer
{
    //----------Private Variables----------//
    private WebClient _client;
    private string _serverAddress;

    private string _downloadDataSaveLocation;

    //----------Public Variables----------//
    public bool IsConnectedToServer
    {
        get
        {
            try
            {
                _client.OpenRead(_serverAddress);
                return true;
            }
            catch (WebException) { return false; }
        }
    }

    //----------Constructors----------//
    public WebServer(string serverAddress)
    {
        _client = new WebClient();
        _client.DownloadDataCompleted += _client_DownloadDataCompleted;
        _client.DownloadProgressChanged += _client_DownloadProgressChanged;
        _client.UploadFileCompleted += _client_UploadFileCompleted;
        _client.UploadProgressChanged += _client_UploadProgressChanged;

        _serverAddress = serverAddress;
    }

    //----------Public Methods----------//
    public void DownloadData(string urlpath, string filepath, bool overwrite = false)
    {
        _downloadDataSaveLocation = filepath;
        if (overwrite || !File.Exists(_downloadDataSaveLocation) )
        {
            Uri uri = new Uri(_serverAddress + urlpath);
            _client.DownloadDataAsync(uri); 
        }
    }

    public void UploadFile(string urlpath, string filepath)
    {
        _client.UploadFileAsync(new Uri(_serverAddress + urlpath), "POST", filepath);
    }

    public void UploadFile(string urlpath, string filepath, string newfilepath)
    {
        _client.UploadFileAsync(new Uri(new Uri(_serverAddress + urlpath), newfilepath), "POST", filepath);
    }

    public void CancelAsync()
    {
        _client.CancelAsync();
    }

    //----------Events----------//
    //---Download---//
    private void _client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        onDownloadProgressChanged(e);
    }

    public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
    protected virtual void onDownloadProgressChanged(DownloadProgressChangedEventArgs e)
    {
        EventHandler<DownloadProgressChangedEventArgs> handler = DownloadProgressChanged;
        if (handler != null)
            handler(this, e);
    }

    private void _client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory +  _downloadDataSaveLocation, e.Result);

        onDownloadDataCompleted(e);
    }

    public event EventHandler<DownloadDataCompletedEventArgs> DownloadDataCompleted;
    protected virtual void onDownloadDataCompleted(DownloadDataCompletedEventArgs e)
    {
        EventHandler<DownloadDataCompletedEventArgs> handler = DownloadDataCompleted;
        if (handler != null)
            handler(this, e);
    }

    //---Upload---//
    private void _client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
        onUploadProgressChanged(e);
    }

    public event EventHandler<UploadProgressChangedEventArgs> UploadProgressChanged;
    protected virtual void onUploadProgressChanged(UploadProgressChangedEventArgs e)
    {
        EventHandler<UploadProgressChangedEventArgs> handler = UploadProgressChanged;
        if (handler != null)
            handler(this, e);
    }

    private void _client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
    {
        onUploadFileCompleted(e);
    }

    public event EventHandler<UploadFileCompletedEventArgs> UploadFileCompleted;
    protected virtual void onUploadFileCompleted(UploadFileCompletedEventArgs e)
    {
        EventHandler<UploadFileCompletedEventArgs> handler = UploadFileCompleted;
        if (handler != null)
            handler(this, e);
    }
}
