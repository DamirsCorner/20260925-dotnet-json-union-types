using System.Text.Json;

namespace JsonUnionTypes;

public class SerializationTests
{
    [Test]
    public void DeserializesMissingValue()
    {
        // language=json
        const string json = """{"Version":null}""";

        var appInfo = JsonSerializer.Deserialize<AppInfo>(json);

        Assert.That(appInfo, Is.Not.Null);
        Assert.That(appInfo.Version.Value, Is.EqualTo(null));
        Assert.That(appInfo.Version.StringValue, Is.EqualTo(null));
    }

    [Test]
    public void DeserializesStringValue()
    {
        // language=json
        const string json = """{"Version":"1.0.0"}""";

        var appInfo = JsonSerializer.Deserialize<AppInfo>(json);

        Assert.That(appInfo, Is.Not.Null);
        Assert.That(appInfo.Version.Value, Is.EqualTo("1.0.0"));
        Assert.That(appInfo.Version.StringValue, Is.EqualTo("1.0.0"));
    }

    [Test]
    public void DeserializesNumericValue()
    {
        // language=json
        const string json = """{"Version":1}""";

        var appInfo = JsonSerializer.Deserialize<AppInfo>(json);

        Assert.That(appInfo, Is.Not.Null);
        Assert.That(appInfo.Version.Value, Is.EqualTo(1));
        Assert.That(appInfo.Version.StringValue, Is.EqualTo("1"));
    }

    [Test]
    public void SerializedMissingValue()
    {
        var appInfo = new AppInfo { Version = new StringOrNumber() };

        var json = JsonSerializer.Serialize(appInfo);

        Assert.That(
            json,
            Is.EqualTo( // language=json
                """{"Version":null}"""
            )
        );
    }

    [Test]
    public void SerializedStringValue()
    {
        var appInfo = new AppInfo { Version = "1.0.0" };

        var json = JsonSerializer.Serialize(appInfo);

        Assert.That(
            json,
            Is.EqualTo( // language=json
                """{"Version":"1.0.0"}"""
            )
        );
    }

    [Test]
    public void SerializedNumericValue()
    {
        var appInfo = new AppInfo { Version = 1 };

        var json = JsonSerializer.Serialize(appInfo);

        Assert.That(
            json,
            Is.EqualTo( // language=json
                """{"Version":1}"""
            )
        );
    }
}
